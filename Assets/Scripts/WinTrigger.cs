using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public delegate void WinTrigged();
    public event WinTrigged OnWinTriggered;

    public delegate void WinSFX(AudioClip clip);
    public event WinSFX OnSFXPlayed;

    public AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(OnWinTriggered != null)
            {
                OnWinTriggered();              
            }
            if(OnSFXPlayed != null)
            {
                OnSFXPlayed(clip);
            }
        }
    }
}
