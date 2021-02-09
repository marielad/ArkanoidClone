using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball") {
            Ball ball = collision.GetComponent<Ball>();
            BallManager.instance.BallList.Remove(ball);
            ball.Destroy();
        }
    }
}
