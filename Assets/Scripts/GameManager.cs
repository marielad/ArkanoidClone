using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverScreen;
    public GameObject winScreen;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI finalScoreText;
    public int availibleLives = 3;
    public int score = 0;

    public int highScore = 0;
    string highScoreKey = "HighScore";
    public int lives { get; set; }

    public bool isGameStarted { get; set; }

    void Awake()
    {
        GameManager.instance = this;
    }

    private void Start()
    {
        GetHighScore();
        this.lives = this.availibleLives;
        Screen.SetResolution(540,960,false);
        Ball.onBallDestroy += OnBallDestroy;
        BrickBehaviour.onBrickDestruction += OnBrickDestruction;
    }

    public void RestartGame() {
        GetHighScore();
        this.lives = this.availibleLives;
        isGameStarted = false;
        score = 0;
        livesText.text = lives.ToString();
        scoreText.text = score.ToString();
        BallManager.instance.ResetBalls();
        BrickManager.instance.LoadLevel();

    }

    public void NextLevel()
    {
        GetHighScore();
        isGameStarted = false;
        livesText.text = lives.ToString();
        scoreText.text = score.ToString();
        BallManager.instance.ResetBalls();
        BrickManager.instance.LoadLevel();

    }

    void GetHighScore() {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        highScoreText.text = highScore.ToString();
    }

    private void OnBrickDestruction(BrickBehaviour brick)
    {
        if (BrickManager.instance.remainingBricks.Count <= 0)
        {
            score += 10 * brick.hits;
            finalScoreText.text = score.ToString();
            if (score > highScore)
            {
                PlayerPrefs.SetInt(highScoreKey, score);
                //PlayerPrefs.Save();
            }
            winScreen.SetActive(true);
        }
        else {
            score += 10 * brick.scoreMulti;
            if (score > highScore)
            {
                PlayerPrefs.SetInt(highScoreKey, score);
                PlayerPrefs.Save();
            }
            scoreText.text = score.ToString();
        }
    }

    private void OnBallDestroy(Ball ball) {
        if (BallManager.instance.BallList.Count <= 0) {
            lives--;
            if (this.lives <= 0){
                gameOverScreen.SetActive(true);
            }
            else {
                livesText.text = lives.ToString();
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
