using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject gameOverPanel, winPanel;

    WinTrigger winTrigger;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start() {
        PlayerPrefs.GetInt("currentLevel", 0);

        winTrigger = FindObjectOfType<WinTrigger>();
        gameManager = FindObjectOfType<GameManager>();

        winTrigger.OnWinTriggered += gameManager.OnLevelEndened;
    }

    public void OnDie() {
        print("Abrir tela de derrota");
    }

    public void OnLevelEndened() {
        print("Abrir tela de vitoria");
    }

    public void NextLevelButton() {
        int i = PlayerPrefs.GetInt("currentLevel", 0) + 1;
        PlayerPrefs.SetInt("CurrentLevel", i);
        //tocar efeito de som do botão
        //chamar função de carregamento de fase
        Invoke("LoadNewLevel", 0.5f);
        //talvez seja interessante chamar um fade para essa transição 
        Invoke("ResetPlayerToStart", 0.6f);
    }

    public void ResetPlayerToStart() {
        //reposicionar player no inicio da fase
    }

    public void RestartLevel() {
        //reiniciar a fase
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
}
