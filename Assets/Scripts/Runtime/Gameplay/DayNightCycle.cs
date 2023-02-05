using UnityEngine;

namespace Runtime.Gameplay
{
    public class DayNightCycle : MonoBehaviour
    {
        [SerializeField] private float dayCycle = 20;
        
        private Vector3 rotation = Vector3.zero;
        
        private void Update()
        {
            rotation.x = dayCycle * Time.deltaTime;
            transform.Rotate(rotation, Space.World);
        }
    }
}