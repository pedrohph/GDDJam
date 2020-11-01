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

    public float lerpSpeed;
    public AudioClip[] winSounds;
    public AudioSource winSound;
    public GameObject winParticle;


    public Image progressBar;

    private void OnEnable()
    {
        manager = FindObjectOfType<GameManager>();
        percentage = manager.percent / 100;
        Classify();
        progressBar.fillAmount = 0;
        Invoke("EndEffects", 2);
        title.gameObject.SetActive(false);
    }

    void Update()
    {
        if (percentage > 1)
        {
            percentage = 1;
        }
        
        progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, percentage, Time.deltaTime * lerpSpeed);


    }

    void EndEffects()
    {
        title.gameObject.SetActive(true);
        winSound.Play();
        //particles play
    }

    public void Classify()
    {
        //0 a 30 noob, 31 a 85 pro e 86 ate 100 hacker
        if (percentage <= 0.3f)
        {
            title.sprite = titles[0];
            winSound.clip = winSounds[0];
        }
        else if (percentage > 0.3f && percentage <= 0.85f)
        {
            title.sprite = titles[1];
            winSound.clip = winSounds[1];
        }
        else
        {
            title.sprite = titles[2];
            winSound.clip = winSounds[2];
        }
    }
}
