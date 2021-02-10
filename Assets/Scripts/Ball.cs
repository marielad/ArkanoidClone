using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Ball : MonoBehaviour
{
    public static event Action<Ball> onBallDestroy;
    internal void Destroy()
    {
        onBallDestroy?.Invoke(this);
        Destroy(gameObject,1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            AudioManager.instance.PlayBounceSound();
            Vector2 newVelocity = BallManager.instance.rb.velocity;
            newVelocity += collision.contacts[0].normal * UnityEngine.Random.Range(0f, 0.5f);
            BallManager.instance.rb.velocity = newVelocity;

        }
        else if (collision.gameObject.tag == "TopWall")
        {
            AudioManager.instance.PlayBounceSound();
            //Vector2 newVelocity = BallManager.instance.rb.velocity;
            //newVelocity.x += Mathf.Sign(newVelocity.y) * UnityEngine.Random.Range(0f, 0.5f);
            //BallManager.instance.rb.velocity = newVelocity;
        }
    }
}
