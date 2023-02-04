using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Systems.GameEvents
{
    [System.Serializable, CreateAssetMenu(fileName = "New Int Game Event", menuName = "Game Events/New Int Game Event")]
    public class IntGameEvent : ScriptableObject
    {
        private readonly HashSet<IntEventListener> _eventListeners = new HashSet<IntEventListener>();
        public int passableInteger = 0;

        // TODO: Add debug global flag to set this to false
        [SerializeField] private bool _dispatchMessage = false;

        public void Raise(int item)
        {
            Debug.Log(item);
            foreach (var listener in _eventListeners)
            {
                listener.OnEventRaised(item);
                if (_dispatchMessage) Debug.LogFormat("Event named : {0} was raised", this.name);
            }
        }
        public void RegisterListener(IntEventListener listener) => _eventListeners.Add(listener);
        public void UnregisterListener(IntEventListener listener) => _eventListeners.Remove(listener);
    }
}
