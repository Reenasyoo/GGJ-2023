using System.Collections.Generic;
using UnityEngine;

namespace Lumios.System.ScriptableValues
{
    public abstract class DoubleValueAsset<TKey, TValue> : ScriptableObject
    {
        // public T value;
        // public T GetValue() => value;
        // public void SetValue(T input) => value = input;
        
        public Dictionary<TKey, TValue> values = new Dictionary<TKey, TValue>();

        public void AddPair(TKey key, TValue value)
        {
            values.Add(key, value);
        }
    }
}