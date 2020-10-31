﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource sfx;
    public AudioSource music;

    WinTrigger winTrigger;

    private void Start()
    {
        winTrigger = FindObjectOfType<WinTrigger>();
        sfx = GetComponent<AudioSource>();
        winTrigger.OnSFXPlayed += PlaySFX;
    }

    public void PlaySFX(AudioClip clip)
    {
        sfx.clip = clip;
        sfx.Play();
    }
}
