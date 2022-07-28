using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Andromeda.Saving
{
    [ExecuteAlways]
    public class SavableEntity : MonoBehaviour
    {
        private const string IdentifierPropertyPath = "uniqueIdentifier";

        [SerializeField] private string uniqueIdentifier = "";

        public string UniqueIdentifier
        {
            get { return uniqueIdentifier; }
        }

        private static readonly Dictionary<string, SavableEntity> GlobalLookup = new();

        private ISavableComponent[] _savableComponents;

        private void Awake()
        {
            _savableComponents = GetComponents<ISavableComponent>();
        }

        public EntityState CaptureState()
        {
            EntityState state = new EntityState();

            foreach (ISavableComponent savable in _savableComponents)
            {
                state.components[savable.GetType().ToString()] = savable.CaptureState();
            }

            return state;
        }

        public void RestoreState(EntityState state)
        {
            foreach (ISavableComponent savable in _savableComponents)
            {
                string componentId = savable.GetType().ToString();
                if (state.components.ContainsKey(componentId))
                {
                    savable.RestoreState(state.components[componentId]);
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

            GlobalLookup[property.stringValue] = this;
        }

        private bool IsUnique(string candidate)
        {
            if ((!GlobalLookup.ContainsKey(candidate)) || GlobalLookup[candidate] == this)
            {
                return true;
            }

            if (GlobalLookup[candidate] == null || GlobalLookup[candidate].uniqueIdentifier != candidate)
            {
                GlobalLookup.Remove(candidate);
                return true;
            }

            return false;
        }
#endif // UNITY_EDITOR
    }
}