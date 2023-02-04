using UnityEngine;

namespace Runtime.Resources
{
    public class ScriptableResource: ScriptableObject
    {
        public string Name;
        public ResourceType Type;
        private int _amount = 0;
        public void SetResourceAmount(int amount) => _amount = amount;
        public int GetAmount() => _amount;
    }
}