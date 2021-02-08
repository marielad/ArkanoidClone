using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField]
    Ball ballPrefab;

    Ball firstBall;
    Rigidbody2D rb;
    Vector3 startPosition;
    
    public float ballSpeed = 1.5f;
    public List<Ball> BallList { get; set; }

    private void Start()
    {
        InitBall();
    }

    private void Update()
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

    public Vector2 BallVelocity()
    {
        return new Vector2(Random.Range(-1f, 1f), 1f) * ballSpeed;
    }
    private void InitBall() {
        startPosition = new Vector3(PlayerBehaviour.instance.GetPosition().x, PlayerBehaviour.instance.GetPosition().y + 0.45f, 0);
        firstBall = Instantiate(ballPrefab, startPosition, Quaternion.identity); //sin rotación
        rb = firstBall.GetComponent<Rigidbody2D>();

        this.BallList = new List<Ball> {
            firstBall
        };
    }
}
