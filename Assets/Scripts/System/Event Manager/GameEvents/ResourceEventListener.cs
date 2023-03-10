using Runtime.Resources;
using UnityEngine;
using UnityEngine.Events;

namespace Systems.GameEvents
{
    [System.Serializable]
    public class ResourceEventListener
    {
        [Tooltip("Event to register with.")] public ResourceGameEvent GameEvent = null;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<Resource> Response = null;

        public void OnEventRaised(Resource item) => Response.Invoke(item);
    }
}