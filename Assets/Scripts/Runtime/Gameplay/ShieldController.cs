using Lumios.System.ScriptableValues;
using UnityEngine;

namespace Runtime.Gameplay
{
    public class ShieldController : MonoBehaviour
    {
        [SerializeField] private IntValue shieldHealth;

        public void TakeDamage(int amount)
        {
            shieldHealth.value += amount;
        }
    }
}