using UnityEngine;

namespace Systems.GameEvents
{
    [System.Serializable]
    public class IntGameEventListener : MonoBehaviour
    {
        [SerializeField] private IntEventListener[] listeners = new IntEventListener[1];
        
        private void OnEnable()
        {
            foreach (var eventListener in listeners)
            {
                eventListener.GameEvent.RegisterListener(eventListener);    
            }
        }

        private void OnDisable()
        {
            foreach (var eventListener in listeners)
            {
                eventListener.GameEvent.UnregisterListener(eventListener);
            }
        }
    }
}