using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    GameManager manager;
    float percentage;
    int rank;
    public Sprite[] titles;
    public Image title;

    public Image progressBar;

    private void OnEnable()
    {
        manager = FindObjectOfType<GameManager>();
        percentage = manager.ProgressCalculator();
        Classify();
    }

    void Update()
    {
        while (progressBar.fillAmount < manager.ProgressCalculator())
        {
            progressBar.fillAmount += Time.deltaTime;
        }
    }

    public void Classify()
    {
        //0 a 30 noob, 31 a 85 pro e 86 ate 100 hacker
        if (percentage <= 30)
        {
            title.sprite = titles[0];
        }
        else if (percentage > 30 && percentage <= 85)
        {
            title.sprite = titles[1];
        }
        else
        {
            title.sprite = titles[2];
        }
    }
}
