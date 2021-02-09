using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public static BrickManager instance;

    public BrickBehaviour brickPrefab;
    public Sprite[] sprites;
    public int rows;
    public int columns;
    public float initialBrickSpawnPositionX = -3.5f;
    public float initialBrickSpawnPositionY = 6.5f;
    public float spacing = 0.25f;
    public float brickWidth = 0.64f;
    public float brickHeight = 0.32f;
    public int[,] level { get; set; }
    public List<BrickBehaviour> remainingBricks { get; set; }
    public int initialBricksCount { get; set; }


    GameObject bricksContainer;
    
    void Awake()
    {
        BrickManager.instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.level = this.GenerateLevel();
        this.remainingBricks = new List<BrickBehaviour>();
        this.bricksContainer = new GameObject("bricksContaines");
        GenerateBricks();
    }

    public void LoadLevel()
    {
        BallManager.instance.ResetBalls();
        GameManager.instance.isGameStarted = false;
        this.level= GenerateLevel();
        GenerateBricks();
    }
    private int[,] GenerateLevel()
    {
        int[,] currentLevel = new int[rows, columns];

        for (int i = 0; i < currentLevel.GetLength(0); i++)
        {
            for (int j = 0; j < currentLevel.GetLength(1); j++)
                currentLevel[i, j] = Random.Range(0,2); //cambiar a 0,2 para pruebas
        }
        return currentLevel;
    }

    private void ClearRemainingBricks()
    {
        foreach (BrickBehaviour brick in this.remainingBricks)
        {
            Destroy(brick.gameObject);
        }
    }

    public void GenerateBricks()
    {
        ClearRemainingBricks();
        this.remainingBricks = new List<BrickBehaviour>();
        int[,] currentLevelData = this.level;
        float currentSpawnX = initialBrickSpawnPositionX;
        float currentSpawnY = initialBrickSpawnPositionY;
        float zShift = 0f;

        for (int row = 0; row < this.rows; row++)
        {
            for (int col = 0; col < this.columns; col++)
            {
                int brickType = currentLevelData[row, col];

                if (brickType > 0)
                {
                    BrickBehaviour newBrick = Instantiate(brickPrefab, new Vector3(currentSpawnX, currentSpawnY, 0.0f - zShift), Quaternion.identity) as BrickBehaviour;
                    newBrick.Init(bricksContainer.transform, this.sprites[brickType - 1], brickType);

                    this.remainingBricks.Add(newBrick);
                    zShift += 0.0001f;
                }

                currentSpawnX += brickWidth + spacing;
                if (col + 1 == this.columns)
                {
                    currentSpawnX = initialBrickSpawnPositionX;
                }
            }

            currentSpawnY -= brickHeight + spacing;
        }

        this.initialBricksCount = this.remainingBricks.Count;
    }


}
