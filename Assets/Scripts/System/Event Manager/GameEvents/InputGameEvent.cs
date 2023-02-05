using System.Collections.Generic;
using Runtime.Actor;
using UnityEngine;

namespace Systems.GameEvents
{
    [System.Serializable, CreateAssetMenu(fileName = "New Input Game Event", menuName = "Game Events/New Input Game Event")]
    public class InputGameEvent : ScriptableObject
    {
        private readonly HashSet<InputEventListener> _eventListeners = new HashSet<InputEventListener>();
        public int passableInteger = 0;

        // TODO: Add debug global flag to set this to false
        [SerializeField] private bool _dispatchMessage = false;

        public void Raise(ActionInput item)
        {
            foreach (var listener in _eventListeners)
            {
                listener.OnEventRaised(item);
                if (_dispatchMessage) Debug.LogFormat("Event named : {0} was raised", this.name);
            }
        }
        public void RegisterListener(InputEventListener listener) => _eventListeners.Add(listener);
        public void UnregisterListener(InputEventListener listener) => _eventListeners.Remove(listener);
    }
}