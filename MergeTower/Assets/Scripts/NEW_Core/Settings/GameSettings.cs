using Core;
using Core.StorageSystem;
using UnityEngine;

public class GameSettings
{
    private const string SETTINGS_FILE_NAME = "GameSettings.data";

    public AudioSettingsCore AudioSettings { get; }

    private Storage settingsStorage;

    public GameSettings()
    {
        settingsStorage = new FileStorage(SETTINGS_FILE_NAME);
        settingsStorage.Load();

        AudioSettings = new AudioSettingsCore(settingsStorage);
    }

    public void Save()
    {
        AudioSettings.Save();
    }
}
