using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAudio : MonoBehaviour
{

    public AudioClip[] theClip;
    public AudioSource audioData;

    public void FootStepAudio()
    {
        audioData.clip = theClip[0];
        audioData.volume = 1;
        audioData.Play(0);
    }
    public void EscapeSound()
    {
        
        audioData.clip = theClip[1];
        audioData.volume = 1;
        audioData.Play(0);
    }
    public void ScreamSound()
    {
        audioData.clip = theClip[2];
        audioData.volume = 1;
        audioData.Play(0);
    }
    public void HitBeak()
    {
        audioData.clip = theClip[3];
        audioData.volume = 1;
        audioData.Play(0);
    }
    public void HitClaw()
    {
        audioData.clip = theClip[4];
        audioData.volume = 1;
        audioData.Play(0);
    }


}
