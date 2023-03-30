using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject
{
    [TaskCategory("Unity/GameObject")]
    [TaskDescription("Instantiates a new GameObject. Returns Success.")]
    public class Instantiate : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [Tooltip("The position of the new GameObject")]
        public SharedVector3 position;
        [Tooltip("The rotation of the new GameObject")]
        public SharedQuaternion rotation = Quaternion.identity;
        [SharedRequired]
        [Tooltip("The instantiated GameObject")]
        public SharedGameObject storeResult;

        public override TaskStatus OnUpdate()
        {
            storeResult.Value = GameObject.Instantiate(targetGameObject.Value, 
                                                        new Vector3(Random.Range(50.0f,90.0f), 10.0f, Random.Range(40.0f, 80.0f)), 
                                                        rotation.Value) as GameObject;
            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetGameObject = null;
        }
    }
}