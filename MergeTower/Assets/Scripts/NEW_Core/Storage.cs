using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Core
{
    public abstract class Storage : MonoBehaviour
    {
        private static BinaryFormatter formatter;

        public GameData Data { get; protected set; }

        public static BinaryFormatter Formatter
        {
            get
            {
                if(formatter == null)
                {
                    formatter = new BinaryFormatter();
                }

                return formatter;
            }
        }

        #region SAVE

        public void Save()
        {
            SaveInternal();
        }

        public void SaveAsync(Action callback = null)
        {
            SaveAsyncInternal(callback);
        }

        public Coroutine SaveWithRoutine(Action callback = null)
        {
            return SaveWithRoutineInternal(callback);
        }

        protected abstract void SaveInternal();
        protected abstract void SaveAsyncInternal(Action callback = null);
        protected abstract Coroutine SaveWithRoutineInternal(Action callback = null);

        #endregion

        #region LOAD

        public void Load()
        {
            LoadInternal();
        }

        public void LoadAsync(Action<GameData> callback = null)
        {
            LoadAsyncInternal(callback);
        }

        public Coroutine LoadWithRoutine(Action<GameData> callback = null)
        {
            return LoadWithRoutineInternal(callback);
        } 

        protected abstract void LoadInternal();
        protected abstract void LoadAsyncInternal(Action<GameData> callback = null);
        protected abstract Coroutine LoadWithRoutineInternal(Action<GameData> callback = null);

        #endregion

        public T Get<T>(string key)
        {
            return Data.Get<T>(key);
        }
    }
}
