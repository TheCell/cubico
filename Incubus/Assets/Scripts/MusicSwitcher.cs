using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    public AudioSource AS;
    public AudioSource AS2;

    public bool NormalTrueCustomFalse;
    public RandomSoundStart RSS;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StopSound()
    {
        AS.Stop();
    }

    public void SS2()
    {
        AS2.Stop();
    }

    public void PST2()
    {
        AS.Play();
    }

    public void PlayST()
    {
        AS2.Play();
    }

    public void SwitchToCustom()
    {
        SS2();
        PST2();
        RSS.FadeToCustom();
    }

    public void SwitchToNormal()
    {
        StopSound();
        PlayST();
        RSS.FadeToNormal();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            NormalTrueCustomFalse = !NormalTrueCustomFalse;
            if(NormalTrueCustomFalse == false)
            {
                SwitchToCustom();
            }
            if(NormalTrueCustomFalse == true)
            {
                SwitchToNormal();
            }
        }
    }
}
