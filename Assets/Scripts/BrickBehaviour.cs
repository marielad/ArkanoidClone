using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BrickBehaviour : MonoBehaviour
{
    SpriteRenderer sr;
    public int scoreMulti = 1;

    public int hits;
    public static event Action<BrickBehaviour> onBrickDestruction;

    private void Awake()
    {
        this.sr = this.GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hits--;
        if (hits <= 0)
        {
            BrickManager.instance.remainingBricks.Remove(this);
            onBrickDestruction?.Invoke(this);
            Destroy(this.gameObject);
        }
        else {
            this.sr.sprite = BrickManager.instance.sprites[this.hits -1];
        }
    }

    public void Init(Transform tf, Sprite sprite, int hitpoints) {
        this.transform.SetParent(tf);
        this.sr.sprite = sprite;
        this.hits = hitpoints;
        this.scoreMulti = hitpoints;
    }

}
