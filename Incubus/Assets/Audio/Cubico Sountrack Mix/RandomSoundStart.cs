using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundStart : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public MusicSwitcher MS;

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0, targetVolume, currentTime / duration);
            yield return null;
        }

        yield break;
    }

    private void Start()
    {
        float audiolength = musicSource.clip.length;
        musicSource.time = Random.Range(0, audiolength);
        StartCoroutine(StartFade(musicSource, 3f, musicSource.volume));
    }

    public void FadeToCustom()
    {
        float audiolength = MS.AS2.clip.length;
        MS.AS2.time = Random.Range(0, audiolength);
        StartCoroutine(StartFade(MS.AS2, 3f, MS.AS2.volume));
    }

    public void FadeToNormal()
    {
        float audiolength = MS.AS.clip.length;
        MS.AS.time = Random.Range(0, audiolength);
        StartCoroutine(StartFade(MS.AS, 3f, MS.AS.volume));
    }
}
