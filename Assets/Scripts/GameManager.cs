using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject winPanel;
    public Transform levelSpawnPos;
    public GameObject[] levels;

    WinTrigger winTrigger;
    GameManager gameManager;

    float totalTreeCount;
    float lootCount;

    // Start is called before the first frame update
    void Start() {
        PlayerPrefs.GetInt("currentLevel", 0);
        TotalTreeCalculator();
        Instantiate(levels[PlayerPrefs.GetInt("currentlevel",0)], levelSpawnPos.position,Quaternion.identity);
        winTrigger = FindObjectOfType<WinTrigger>();
        gameManager = FindObjectOfType<GameManager>();


        winTrigger.OnWinTriggered += gameManager.OnLevelEndened;
    }

    void TotalTreeCalculator()
    {
        totalTreeCount = FindObjectsOfType<Tree>().Length * 5;
    }

    float ProgressCalculator()
    {
        float percentage;
        percentage = (lootCount * 100) / totalTreeCount;
        return percentage;
    }

    public void OnDie() {
        PlayerPrefs.SetInt("win", 0);
        Invoke("RestartLevel", 1f);
    }

    public void OnLevelEndened() {
        print(ProgressCalculator());
        winPanel.SetActive(true);
    }

    public void NextLevelButton() {
        int i = PlayerPrefs.GetInt("currentLevel", 0) + 1;
        PlayerPrefs.SetInt("win", 1);
        PlayerPrefs.SetInt("CurrentLevel", i);
        Invoke("RestartLevel", 1f);
    }

    public void RestartLevel() {
        SceneManager.LoadScene("SampleScene");
    }

    public void ListenGameOver(Obstacles obstacle) {
        obstacle.DefinedGameOver += OnDie;
    }

    public void RemoveListenGameOver(Obstacles obstacle) {
        obstacle.DefinedGameOver -= OnDie;
    }

    public void addLoot()
    {
        lootCount++;
    }

    public void ListenWoodLoot(WoodLoot woodLoot)
    {
        woodLoot.CollectedLoot += addLoot;
    }
}
