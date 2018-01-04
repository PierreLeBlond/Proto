using UnityEngine;
using System;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Player                   player;
    public ItemManager              itemManager;
    public Count                    count;

    public GameObject               mainMenu;

    public GameObject               gameOver;
    public GameObject               pause;

    public Camera                   gameCamera;
    public Camera                   menuCamera;

    private bool                    _gameOver = false;
    private bool                    _play = false;
    private bool                    _pause = false;

    public void Start() {
        PauseGame();
        itemManager.SpamItems();
        gameOver.SetActive(false);
        pause.SetActive(false);
    }

    public void Update() {
        if(!_gameOver && Input.GetKeyDown("space")) {
            if(_play) {
                Pause();
            } else {
                Play();
            }
        }
    }

    public void Restart() {
        _gameOver = false;
        itemManager.Clean();
        itemManager.SpamItems();
        player.SetLevel(1);
        count.Reset();
        gameOver.SetActive(false);
    }


    private void PauseGame() {
        gameCamera.gameObject.SetActive(false);
        menuCamera.gameObject.SetActive(true);
        mainMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void PlayGame() {
        gameCamera.gameObject.SetActive(true);
        menuCamera.gameObject.SetActive(false);
        mainMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Resume() {
        if(_gameOver) {
            Restart();
        } else {
            _pause = false;
            pause.SetActive(false);
        }
    }

    public void Play() {
        if(_gameOver) {
            Restart();
        } else if(_pause) {
            Resume();
        } else {
            Start();
        }
        _play = true;
        PlayGame();
    }

    public void Pause() {
        _play = false;
        _pause = true;
        pause.SetActive(true);
        PauseGame();
    }

    public void GameOver() {
        _play = true;
        _gameOver = true;
        gameOver.SetActive(true);
        PauseGame();
    }
}

