using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject gameOverPanel, winPanel;

    WinTrigger winTrigger;
    GameManager gameManager;

    int totalTreeCount;
    int lootCount;

    // Start is called before the first frame update
    void Start() {
        PlayerPrefs.GetInt("currentLevel", 0);
        TotalTreeCalculator();
        winTrigger = FindObjectOfType<WinTrigger>();
        gameManager = FindObjectOfType<GameManager>();

        winTrigger.OnWinTriggered += gameManager.OnLevelEndened;
    }

    void TotalTreeCalculator()
    {
        totalTreeCount = FindObjectsOfType<Tree>().Length;
    }

    float ProgressCalculator()
    {
        float percentage;
        percentage =  (lootCount / 100) * totalTreeCount;
        return percentage;
    }

    public void OnDie() {
        print("Abrir tela de derrota");
    }

    public void OnLevelEndened() {
        ProgressCalculator();

        print("Abrir tela de vitoria");
        Invoke("RestartLevel", 1f);
    }

    public void NextLevelButton() {
        int i = PlayerPrefs.GetInt("currentLevel", 0) + 1;
        PlayerPrefs.SetInt("CurrentLevel", i);
        //tocar efeito de som do botão
        //chamar função de carregamento de fase
        //Invoke("LoadNewLevel", 0.5f);
        //talvez seja interessante chamar um fade para essa transição 
        //Invoke("ResetPlayerToStart", 0.6f);

    }

    public void ResetPlayerToStart() {
        //reposicionar player no inicio da fase
    }

    public void RestartLevel() {
        //reiniciar a fase
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadNewLevel() {
        //reposicionar player
        //instanciar nova fase
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
