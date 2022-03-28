using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class GameData : MonoBehaviour
    {

        public Dictionary<string, object> dataMap = new Dictionary<string, object>();

        public T Get<T>(string key)
        {
            dataMap.TryGetValue(key, out var foundValue);
            if (foundValue != null)
                return (T)foundValue;
            return default;
        }
    }
}