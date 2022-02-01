using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Andromeda.Saving
{
    [ExecuteAlways]
    public class SaveableEntity : MonoBehaviour
    {
        private const string IdentifierPropertyPath = "_uniqueIdentifier";

        [SerializeField]
        private string _uniqueIdentifier = "";
        public string uniqueIdentifier { get { return _uniqueIdentifier; } }

        private static Dictionary<string, SaveableEntity> _globalLookup = new Dictionary<string, SaveableEntity>();

        public EntityState CaptureState()
        {
            EntityState state = new EntityState();

            foreach (ISaveableComponent saveable in GetComponents<ISaveableComponent>())
            {
                state.components[saveable.GetType().ToString()] = saveable.CaptureState();
            }

            return state;
        }

        public void RestoreState(EntityState state)
        {
            foreach (ISaveableComponent saveable in GetComponents<ISaveableComponent>())
            {
                string componentId = saveable.GetType().ToString();
                if (state.components.ContainsKey(componentId))
                {
                    saveable.RestoreState(state.components[componentId]);
                }
            }
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Application.isPlaying || gameObject.scene.path == "") return;

            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty property = serializedObject.FindProperty(IdentifierPropertyPath);

            if (string.IsNullOrEmpty(property.stringValue) || !IsUnique(property.stringValue))
            {
                property.stringValue = Guid.NewGuid().ToString();
                serializedObject.ApplyModifiedProperties();
            }

            _globalLookup[property.stringValue] = this;
        }

        private bool IsUnique(string candidate)
        {
            if ((!_globalLookup.ContainsKey(candidate)) || _globalLookup[candidate] == this)
            {
                return true;
            }

            if (_globalLookup[candidate] == null || _globalLookup[candidate].uniqueIdentifier != candidate)
            {
                _globalLookup.Remove(candidate);
                return true;
            }

            return false;
        }
#endif // UNITY_EDITOR
    }
}
