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
    public float lootCount;
    public float percent;

    public GameObject explosion;

    public Levels levelsReader;

    // Start is called before the first frame update
    void Start() {
        int i = PlayerPrefs.GetInt("currentLevel", 0);
        if(i >= levelsReader.levels.Length) {
            i = 0;
            PlayerPrefs.SetInt("currentLevel", 0);
        }
        Instantiate(levelsReader.levels[i], levelSpawnPos.position,Quaternion.identity);
        winTrigger = FindObjectOfType<WinTrigger>();
        gameManager = FindObjectOfType<GameManager>();
        TotalTreeCalculator();

        winTrigger.OnWinTriggered += gameManager.OnLevelEndened;
    }

    void TotalTreeCalculator()
    {
        totalTreeCount = FindObjectsOfType<Tree>().Length * 5;
    }

    public float ProgressCalculator()
    {
        float percentage;
        percentage = (lootCount * 100) / totalTreeCount;
        return percentage;
    }

    public void OnDie() {
        Vector3 camPos = Camera.main.transform.position;
        camPos.z += 10;
        Instantiate(explosion, camPos, transform.rotation, Camera.main.transform);
        PlayerPrefs.SetInt("win", 0);
        Invoke("RestartLevel", 1.5f);
    }

    public void OnLevelEndened() {
        percent = ProgressCalculator();
        Invoke("OpenEndPanel", 2.3f);
    }

    void OpenEndPanel()
    {
        winPanel.SetActive(true);
        Invoke("NextLevelButton", 3);
    }

    public void NextLevelButton() {
        int i = PlayerPrefs.GetInt("currentLevel", 0);
        i++;
        PlayerPrefs.SetInt("win", 1);
        PlayerPrefs.SetInt("currentLevel", i);
        Invoke("RestartLevel", 2.5f);
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
