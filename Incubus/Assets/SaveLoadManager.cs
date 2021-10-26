using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadManager : MonoBehaviour
{
	public Slider cameraSpeedSlider;
	public Slider audioLevel;
	public Toggle invertCamera;
	public Toggle preloadLevel;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Save()
    {
        PlayerPrefs.SetInt("CameraInvert", invertCamera.isOn?1:0);
		PlayerPrefs.SetFloat("CameraSpeed", cameraSpeedSlider.value);
		PlayerPrefs.SetFloat("AudioVolume", AudioListener.volume);
		PlayerPrefs.SetInt("PreloadLevel", preloadLevel.isOn?1:0);
		PlayerPrefs.Save();
    }

    public void Load()
    {
		if(PlayerPrefs.HasKey("CameraSpeed"))
		{
    		PlayerCamera.CameraMultipier = PlayerPrefs.GetFloat("CameraSpeed");
			cameraSpeedSlider.value = PlayerCamera.CameraMultipier;
			PlayerCamera.InvertCamera = PlayerPrefs.GetInt("CameraInvert")==1;
			invertCamera.isOn = PlayerCamera.InvertCamera;
			audioLevel.value = PlayerPrefs.GetFloat("AudioVolume");
			AudioListener.volume = audioLevel.value;
			preloadLevel.isOn = PlayerPrefs.GetInt("PreloadLevel")==1;
			AdditionalSceneLoader.PreloadLevel = preloadLevel.isOn;
		}
		else
		{
			PlayerPrefs.SetInt("CameraInvert", 0);
			PlayerPrefs.SetFloat("CameraSpeed", 1);
			PlayerPrefs.SetFloat("AudioVolume", 0.5f);
			PlayerPrefs.SetInt("PreloadLevel", 0);
			PlayerPrefs.Save();
		}
    }
}
