using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverScreen;
    public GameObject winScreen;

    public int lives = 3;

    public bool isGameStarted { get; set; }

    void Awake()
    {
        GameManager.instance = this;
    }

    private void Start()
    {
        Screen.SetResolution(540,960,false);
        Ball.onBallDestroy += OnBallDestroy;
        BrickBehaviour.onBrickDestruction += OnBrickDestruction;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnBrickDestruction(BrickBehaviour brick)
    {
        if (BrickManager.instance.remainingBricks.Count <= 0)
        {
                winScreen.SetActive(true);
        }
    }

    private void OnBallDestroy(Ball ball) {
        if (BallManager.instance.BallList.Count <= 0) {
            lives--;
            if (this.lives <= 0){
                gameOverScreen.SetActive(true);
            }
            else {
                BallManager.instance.ResetBalls();
                isGameStarted = false;
                BrickManager.instance.GenerateBricks();
            }
        }
    }

    private void Unsuscribe()
    {
        Ball.onBallDestroy -= OnBallDestroy;
        BrickBehaviour.onBrickDestruction -= OnBrickDestruction;

    }
}
