using Lumios.System.ScriptableValues;
using UnityEngine;

namespace Runtime.Resources
{
    [System.Serializable, CreateAssetMenu(fileName = "New Resource", menuName = "Resources/New Resource")]
    public class ScriptableResource : ScriptableObject
    {
        public string Name;
        public ResourceType Type;
        public IntValue amount;
        public int reqAmount;
    }
}