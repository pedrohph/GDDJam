using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public delegate void WinTrigged();
    public event WinTrigged OnWinTriggered;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(OnWinTriggered != null)
            {
                OnWinTriggered();
            }
        }
    }
}
