using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource sfx;
    public AudioSource music;

    public void PlaySFX(AudioClip clip)
    {
        sfx.clip = clip;
        sfx.Play();
    }
}
