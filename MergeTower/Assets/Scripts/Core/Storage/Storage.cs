using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace Core.StorageSystem
{
    public abstract class Storage
    {
        private static BinaryFormatter formatter;

        protected GameData data { get; set; }

        protected static BinaryFormatter m_formatter
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

        protected abstract void SaveInternal();
        protected abstract void SaveWithCallbackInternal(Action callback = null);

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

        protected abstract void LoadInternal();
        protected abstract void LoadWithCallbackInternal(Action<GameData> callback = null);

        #endregion

        public T Get<T>(string key)
        {
            return data.Get<T>(key);
        }

        public T Get<T>(string key, T valueByDefault)
        {
            return data.Get<T>(key, valueByDefault);
        }

        public void Set<T>(string key, T value)
        {
            data.Set(key, value);
        }
    }
}
