using Runtime.Actor;
using UnityEngine;
using UnityEngine.Events;

namespace Systems.GameEvents
{
    [System.Serializable]
    public class InputEventListener
    {
        [Tooltip("Event to register with.")] public InputGameEvent GameEvent = null;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<ActionInput> Response = null;

        public void OnEventRaised(ActionInput item) => Response.Invoke(item);
    }
}