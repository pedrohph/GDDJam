using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    static AudioManager instance;

    public static AudioManager Instance => instance;

    public AudioSource[] sfx;
    public AudioSource music;

    WinTrigger winTrigger;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start() {
        sfx = GetComponents<AudioSource>();
    }

    public void PlaySFX(AudioClip clip) {

        for (int i = 0; i < sfx.Length; i++) {
            if (!sfx[i].isPlaying) {
                sfx[i].clip = clip;
                sfx[i].Play();
                return;
            }
        }

        for (int i = 0; i < sfx.Length; i++) {
            if (sfx[i].clip == clip) {
                sfx[i].clip = clip;
                sfx[i].Play();
                return;
            }
        }

        sfx[0].clip = clip;
        sfx[0].Play();

    }

    /*
    public void ListenSoundsFromObstacles(Obstacles obstacles) {
        obstacles.PlayedSFX += PlaySFX;
    }

    public void RemoveSoundsFromObstacles(Obstacles obstacles) {
        obstacles.PlayedSFX -= PlaySFX;
    }

    public void ListenSoundsFromLoots(WoodLoot loot)
    {
        loot.lootPlayedSFX += PlaySFX;
    }*/
}
