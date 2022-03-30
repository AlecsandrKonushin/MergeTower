using Core.StorageSystem;
using UnityEngine;

public class GameSettings
{
    private const string SETTINGS_FILE_NAME = "GameSettings.data";

    public AudioSettings AudioSettings { get; }

    private Storage settingsStorage;

    public GameSettings()
    {
        settingsStorage = new FileStorage(SETTINGS_FILE_NAME);
    }
}
