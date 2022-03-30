using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.StorageSystem
{
    [Serializable]
    public class GameData : MonoBehaviour
    {
        public List<string> Keys;
        public List<object> Values;

        public Dictionary<string, object> DataMap = new Dictionary<string, object>();

        public void OnBeforeSerialize()
        {
            Keys.Clear();
            Values.Clear();

            foreach (var data in DataMap)
            {
                Keys.Add(data.Key);
                Values.Add(data.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            DataMap = new Dictionary<string, object>();

            if(Keys.Count != Values.Count)
            {
                Debug.Log($"Кол-во ключей не равно кол-ву значений!");
            }

            for (int i = 0; i < Keys.Count; i++)
            {
                DataMap.Add(Keys[i], Values[i]);
            }
        }

        public T Get<T>(string key)
        {
            DataMap.TryGetValue(key, out var foundValue);

            if (foundValue != null)
            {
                return (T)foundValue;
            }

            return default;
        }

        public T Get<T>(string key, T valueByDefault)
        {
            DataMap.TryGetValue(key, out var value);

            if (value != null)
            {
                return (T)value;
            }

            Set(key, valueByDefault);
            return valueByDefault;
        }

        public void Set<T>(string key, T newValue)
        {
            DataMap[key] = newValue;
        }
    }
}