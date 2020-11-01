using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sfx;
    public AudioSource music;

    WinTrigger winTrigger;

    private void Start()
    {
        //winTrigger = FindObjectOfType<WinTrigger>();
        sfx = GetComponents<AudioSource>();
        //winTrigger.OnSFXPlayed += PlaySFX;
    }

    public void PlaySFX(AudioClip clip)
    {
        bool played = false;
        for(int i = 0; i<sfx.Length; i++) {
            if (!sfx[i].isPlaying) {
                played = true;
                sfx[i].clip = clip;
                sfx[i].Play();
            }
        }
        if (played) {
            sfx[0].clip = clip;
            sfx[0].Play();
        }
        
    }

    public void ListenSoundsFromObstacles(Obstacles obstacles) {
        obstacles.PlayedSFX += PlaySFX;
    }

    public void RemoveSoundsFromObstacles(Obstacles obstacles) {
        obstacles.PlayedSFX -= PlaySFX;
    }

    public void ListenSoundsFromLoots(WoodLoot loot)
    {
        loot.lootPlayedSFX += PlaySFX;
    }
}
