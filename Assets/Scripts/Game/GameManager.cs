using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Player player;
    public Score score;
    public Count count;

    public GameObject gameOver;

    public void Restart() {
        score.Clean();
        player.LevelUp();
        count.Reset();
        gameOver.SetActive(false);
    }

    public void GameOver() {
        gameOver.SetActive(true);
    }
}

