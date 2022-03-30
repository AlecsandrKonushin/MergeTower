using Core.StorageSystem;
using System;
using System.Collections;
using System.IO;
using System.Threading;
using UnityEngine;

public class FileStorage : Storage
{
    private const string PATH_FOLDER_SAVE = "Saves";

    private string filePath { get; }

    public FileStorage(string fileName)
    {
        var folderPath = $"{Application.persistentDataPath}/{PATH_FOLDER_SAVE}";

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        filePath = $"{folderPath}/{fileName}";
    }

    protected override void SaveInternal()
    {
        var file = File.Create(filePath);
        m_formatter.Serialize(file, data);
        file.Close();
    }

    protected override void SaveWithCallbackInternal(Action callback = null)
    {
        var thread = new Thread(() => SaveDataInThread(callback));
        thread.Start();
    }

    private void SaveDataInThread(Action callback)
    {
        Save();
        callback?.Invoke();
    }

    protected override void LoadInternal()
    {
        if (!File.Exists(filePath))
        {
            data = new GameData();
            Save();
        }
        else
        {
            var file = File.Open(filePath, FileMode.Open);
            data = (GameData)m_formatter.Deserialize(file);
            file.Close();
        }
    }

    protected override void LoadWithCallbackInternal(Action<GameData> callback = null)
    {
        var thread = new Thread(() => LoadDataInThread(callback));
        thread.Start();
    }

    private void LoadDataInThread(Action<GameData> callback)
    {
        Load();
        callback?.Invoke(data);
    }
}
