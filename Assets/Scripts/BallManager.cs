using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public Ball ballPrefab;

    Ball firstBall;
    Rigidbody2D rb;
    Vector3 startPosition;
    
    public float ballSpeed = 1.5f;
    public List<Ball> BallList { get; set; }
    public static BallManager instance;


    void Awake()
    {
        BallManager.instance = this;
    }

    private void Start()
    {
        InitBall();
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.isGameStarted) {
            startPosition = new Vector3(PlayerBehaviour.instance.GetPosition().x, PlayerBehaviour.instance.GetPosition().y + 0.45f, 0);
            firstBall.transform.position = startPosition;
            if (Input.GetKey(KeyCode.Space)) {
                rb.velocity = BallVelocity();
                GameManager.instance.isGameStarted = true;
            }
        }
    }

    internal void ResetBalls()
    {
        foreach (var ball in this.BallList) {
            Destroy(ball.gameObject);
        }

        InitBall();
    }

    public Vector2 BallVelocity()
    {
        return new Vector2(Random.Range(-1f, 1f), 1f) * ballSpeed;
    }
    void InitBall() {
        startPosition = new Vector3(PlayerBehaviour.instance.GetPosition().x, PlayerBehaviour.instance.GetPosition().y + 0.45f, 0);
        firstBall = Instantiate(ballPrefab, startPosition, Quaternion.identity); //sin rotación
        rb = firstBall.GetComponent<Rigidbody2D>();

        this.BallList = new List<Ball> {
            firstBall
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") {
            rb.velocity = BallVelocity();
        }
    }
}
