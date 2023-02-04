using UnityEngine;

namespace Runtime.Resources
{
    [System.Serializable, CreateAssetMenu(fileName = "New Requirement", menuName = "Resources/New Requirement")]
    public class ScriptableRequirement: ScriptableObject
    {
        public string Name;
        public ResourceType Type;
        private int _amount = 0;
        public void SetResourceAmount(int amount) => _amount = amount;
        public int GetAmount() => _amount;
    }
}