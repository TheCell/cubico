using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class GameEndTrigger : MonoBehaviour
{
	//[SerializeField] private VideoClip closingVideo;
	[SerializeField] private PlayerController playerController;
	[SerializeField] private PlayerCamera playerCamera;
	[SerializeField] private GameObject displayPlane;
	[SerializeField] private AudioSource musicSource;
	private VideoPlayer videoPlayer;

	private void Start()
	{
		if (displayPlane)
        {
			displayPlane.GetComponent<MeshRenderer>().enabled = false;
		}
		
		videoPlayer = displayPlane.GetComponent<VideoPlayer>();
		if (videoPlayer)
		{
			videoPlayer.playOnAwake = false;
			videoPlayer.aspectRatio = VideoAspectRatio.FitInside;
			videoPlayer.loopPointReached += Quit;
		}
	}

	public void prepareVideo()
	{
		videoPlayer.Prepare();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<PlayerController>() != null)
		{
			BlockPlayerMovement();
			if (videoPlayer)
            {
				videoPlayer.SetDirectAudioVolume(0, AudioListener.volume);
			}
			PlayClosingVideo();
		}
	}

	private void BlockPlayerMovement()
	{
		if (playerController)
        {
			playerController.SetInputActive(false);
		}
		if (playerCamera)
        {
			playerCamera.SetInputActive(false);
		}
	}

	private void PlayClosingVideo()
	{
        DisablePostProcessing();
		if (displayPlane)
        {
			displayPlane.GetComponent<MeshRenderer>().enabled = true;
			videoPlayer.Play();
			musicSource.Stop();
		}
		else
        {
			StartCoroutine(DelayedQuit(3));
        }
	}

	private void DisablePostProcessing()
	{
		if (playerCamera)
        {
			playerCamera.GetComponent<PostProcessLayer>().enabled = false;
		}
	}

	private void Quit(VideoPlayer vp)
	{
		videoPlayer.Stop();
		displayPlane.GetComponent<MeshRenderer>().enabled = false;
		playerCamera.GetComponent<PostProcessLayer>().enabled = true;
		Quit();
	}

	private void Quit()
	{
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
		SceneManager.LoadScene(0, LoadSceneMode.Single);
	}

	IEnumerator DelayedQuit(float seconds)
    {
		yield return new WaitForSeconds(seconds);
		Quit();
    }
}
