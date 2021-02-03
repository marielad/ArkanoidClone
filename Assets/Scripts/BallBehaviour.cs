using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallBehaviour : MonoBehaviour
{
    public float speed = 10.0f;
    public float lives = 5;
    float originalSpeed;
    Vector3 direction;
    int playerScore;
    public GameObject gameOverScreen;

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI playerLifeText;


    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = speed;
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (speed < 20)
        {
            speed += Time.deltaTime;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("TopWall"))
        {
            direction = new Vector3(direction.x, direction.y * Random.Range(-1f, 0f), 0f);
        }
        else if (collision.gameObject.tag.Equals("Wall"))
        {
            direction = new Vector3(direction.x * Random.Range(-1f, 0f), direction.y, 0f);
        }
        else if (collision.gameObject.tag.Equals("Player"))
        {
            direction = new Vector3(direction.x, direction.y * Random.Range(-1f, 0f), 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Score") && lives > 0)
        {
            lives--;
        }
        else {
            gameOverScreen.SetActive(true);
        }
        playerLifeText.text = lives.ToString();

        ResetBall();
    }

    void ResetBall()
    {
        speed = originalSpeed;
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 0.01f), 0);
        transform.position = Vector3.zero;
    }

    public void RestartGame() {
        ResetBall();
        lives = 5;
        playerLifeText.text = lives.ToString();
    }
}
