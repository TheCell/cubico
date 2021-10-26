using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAndUpdateOptions : MonoBehaviour
{
	public Slider cameraSpeedSlider;
	public Slider audioLevel;
	public Toggle invertCamera;
	public Toggle preloadLevel;
	public Button backButton;
	public SaveLoadManager SLM;

	public void SetCameraInvertBool(bool value)
	{
		PlayerCamera.InvertCamera = value;
	}

	public void SetCameraSpeed(float value)
	{
		PlayerCamera.CameraMultipier = value;
	}

	public void SetAudioVolume(float value)
	{
		AudioListener.volume = value;
	}

	public void SetPreloadLevel(bool value)
	{
		AdditionalSceneLoader.PreloadLevel = value;
	}

    private void Update()
    {
        PlayerPrefs.SetInt("CameraInvert", invertCamera.isOn?1:0);
		PlayerPrefs.SetFloat("CameraSpeed", cameraSpeedSlider.value);
		PlayerPrefs.SetFloat("AudioVolume", AudioListener.volume);
		PlayerPrefs.SetInt("PreloadLevel", preloadLevel.isOn?1:0);
		PlayerPrefs.Save();
		SLM.Save();
        if (gameObject.activeSelf && Input.GetButtonDown("Cancel"))
        {
            backButton.onClick.Invoke();
        }
		
    }
}