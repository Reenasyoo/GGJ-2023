using System.Collections.Generic;
using Runtime.Resources;
using UnityEngine;

namespace Systems.GameEvents
{
    [System.Serializable, CreateAssetMenu(fileName = "New Resource Game Event", menuName = "Game Events/New Resource Game Event")]
    public class ResourceGameEvent : ScriptableObject
    {
        private readonly HashSet<ResourceEventListener> _eventListeners = new HashSet<ResourceEventListener>();

        // TODO: Add debug global flag to set this to false
        [SerializeField] private bool _dispatchMessage = false;

        public void Raise(Resource item)
        {
            foreach (var listener in _eventListeners)
            {
                listener.OnEventRaised(item);
                if (_dispatchMessage) Debug.LogFormat("Event named : {0} was raised", this.name);
            }
        }
        public void RegisterListener(ResourceEventListener listener) => _eventListeners.Add(listener);
        public void UnregisterListener(ResourceEventListener listener) => _eventListeners.Remove(listener);
    }
}