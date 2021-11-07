using UnityEngine;

public class SaveAndLoadOptions : MonoBehaviour
{
    public void Start()
    {
        LoadSettingsFromFile();
    }

    private void LoadSettingsFromFile()
    {
        if (PersistanceManager.FileExists("playerSettings.json"))
        {
            var saveFile = PersistanceManager.LoadFile("playerSettings.json");

            PlayerCamera.CameraMultipier = saveFile.cameraMultipier;
            PlayerCamera.InvertCamera = saveFile.invertCamera;
            AudioListener.volume = saveFile.soundVolume;
            AdditionalSceneLoader.PreloadLevel = saveFile.preloadLevel;
        }
    }
}
