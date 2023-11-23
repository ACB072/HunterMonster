using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{

    public AudioClip[] theClip;
    public AudioSource audioData;

    public void FootStepAudio()
    {
        audioData.clip = theClip[0];
        audioData.volume = 0.1f;
        audioData.Play(0);
    }
    public void RollStart()
    {
        
        audioData.clip = theClip[1];
        audioData.volume = 2;
        audioData.Play(0);
    }
    public void RollFall()
    {
        audioData.clip = theClip[2];
        audioData.volume = 2;
        audioData.Play(0);
    }
    public void DamageAudio()
    {
        audioData.clip = theClip[3];
        audioData.volume = 0.1f;
        audioData.Play(0);
    }
    public void SwordAudio()
    {
        audioData.clip = theClip[4];
        audioData.volume = 0.1f;
        audioData.Play(0);
    }
    public void SheathAudio()
    {
        audioData.clip = theClip[5];
        audioData.volume = 0.1f;
        audioData.Play(0);
    }

}
