using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    WinTrigger winTrigger;
    GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        winTrigger = FindObjectOfType<WinTrigger>();
        gameManager = FindObjectOfType<GameManager>();

        winTrigger.OnWinTriggered += gameManager.OnLevelEndened;
    }
}
