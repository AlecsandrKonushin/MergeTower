using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Core.StorageSystem
{
    public abstract class Storage
    {
        private static BinaryFormatter formatter;

        public GameData Data { get; protected set; }

        public static BinaryFormatter Formatter
        {
            get
            {
                if (formatter == null)
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

        public void SaveWithCallback(Action callback = null)
        {
            SaveWithCallbackInternal(callback);
        }

        public Coroutine SaveWithRoutine(Action callback = null)
        {
            return SaveWithRoutineInternal(callback);
        }

        protected abstract void SaveInternal();
        protected abstract void SaveWithCallbackInternal(Action callback = null);
        protected abstract Coroutine SaveWithRoutineInternal(Action callback = null);

        #endregion

        #region LOAD

        public void Load()
        {
            LoadInternal();
        }

        public void LoadWithCallback(Action<GameData> callback = null)
        {
            LoadWithCallbackInternal(callback);
        }

        public Coroutine LoadWithRoutine(Action<GameData> callback = null)
        {
            return LoadWithRoutineInternal(callback);
        }

        protected abstract void LoadInternal();
        protected abstract void LoadWithCallbackInternal(Action<GameData> callback = null);
        protected abstract Coroutine LoadWithRoutineInternal(Action<GameData> callback = null);

        #endregion

        public T Get<T>(string key)
        {
            return Data.Get<T>(key);
        }

        public T Get<T>(string key, T valueByDefault)
        {
            return Data.Get<T>(key, valueByDefault);
        }

        public void Set<T>(string key, T value)
        {
            Data.Set(key, value);
        }
    }
}
