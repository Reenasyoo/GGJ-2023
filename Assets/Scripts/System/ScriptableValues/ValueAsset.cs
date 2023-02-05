using UnityEngine;

namespace Lumios.System.ScriptableValues
{
    public abstract class ValueAsset<T> : ScriptableObject
    {
        public T value;
        public T GetValue() => value;
        public void SetValue(T input) => value = input;
    }
}