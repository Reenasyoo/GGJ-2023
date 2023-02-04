using UnityEngine;

namespace Runtime.Resources
{
    [System.Serializable, CreateAssetMenu(fileName = "New Resource", menuName = "Resources/New Resource")]
    public class ScriptableResource: ScriptableObject
    {
        public string Name;
        public ResourceType Type;
        private int _amount = 0;
        public void SetResourceAmount(int amount) => _amount = amount;
        public int GetAmount() => _amount;
    }
}