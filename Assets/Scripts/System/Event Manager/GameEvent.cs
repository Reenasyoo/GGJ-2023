using System.Collections.Generic;
using UnityEngine;

namespace Systems.GameEvents
{
    [System.Serializable, CreateAssetMenu(fileName = "New Game Event", menuName = "Game Events/New Game Event")]
    public class GameEvent : ScriptableObject
    {
        private readonly HashSet<EventListener> _eventListeners = new HashSet<EventListener>();

        // TODO: Add debug global flag to set this to false
        [SerializeField] private bool _dispatchMessage = false;

        public void Raise(object item = default)
        {
            foreach (var listener in _eventListeners)
            {
                listener.OnEventRaised(item);
                if (_dispatchMessage) Debug.LogFormat("Event named : {0} was raised", this.name);
            }
        }
        public void RegisterListener(EventListener listener) => _eventListeners.Add(listener);
        public void UnregisterListener(EventListener listener) => _eventListeners.Remove(listener);
        

    }
}