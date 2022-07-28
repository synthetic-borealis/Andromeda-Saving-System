using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Andromeda.Saving;

public class TransformSaver : MonoBehaviour, ISavableComponent
{
    public class TransformState : ComponentState
    {
        public Vector3 position;
        public Quaternion rotation;
    }

    public ComponentState CaptureState()
    {
        TransformState tranformState = new TransformState
        {
            position = transform.position,
            rotation = transform.rotation
        };

        return tranformState;
    }

    public void RestoreState(ComponentState state)
    {
        TransformState transformState = (TransformState)state;

        transform.position = transformState.position;
        transform.rotation = transformState.rotation;
    }
}
