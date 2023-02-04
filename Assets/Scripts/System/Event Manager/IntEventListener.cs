using UnityEngine;
using UnityEngine.Events;

namespace Systems.GameEvents
{
    [System.Serializable]
    public class IntEventListener
    {
        [Tooltip("Event to register with.")] public IntGameEvent GameEvent = null;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<int> Response = null;

        public void OnEventRaised(int item) => Response.Invoke(item);
    }
}