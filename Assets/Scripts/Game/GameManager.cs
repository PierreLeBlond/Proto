using UnityEngine;
using System;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Player                   player;
    public Score                    score;
    public Count                    count;

    public GameObject               gameOver;
    public GameObject               menu;
    public GameObject               pause;

    private bool                    _gameOver = false;
    private bool                    _play = false;

    public void Start() {
        PauseGame();
        gameOver.SetActive(false);
        pause.SetActive(false);
        menu.SetActive(true);
        //StartGame();
    }

    public void Update() {
        if(!_gameOver && Input.GetKeyDown("space"))
            if(_play)
                PauseGame();
            else
                ResumeGame();
    }

    public void StartGame() {
        menu.SetActive(false);
        PlayGame(true);
    }

    public void RestartGame() {
        _gameOver = false;
        score.Clean();
        player.SetLevel(1);
        count.Reset();
        gameOver.SetActive(false);
        StartGame();
    }

    public void GameOver() {
        PlayGame(false);
        gameOver.SetActive(true);
        _gameOver = true;
    }

    public void PauseGame() {
        PlayGame(false);
        pause.SetActive(true);
    }

    public void ResumeGame() {
        PlayGame(true);
        pause.SetActive(false);
    }

    private void PlayGame(bool play) {
        _play = play;
        Time.timeScale = _play ? 1.0f : 0.0f;
    }
}

