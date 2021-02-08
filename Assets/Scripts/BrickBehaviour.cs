using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BrickBehaviour : MonoBehaviour
{
    SpriteRenderer sr;

    public int hits;
    public static event Action<BrickBehaviour> OnBrickDestruction;

    private void Start()
    {
        this.sr = this.GetComponent<SpriteRenderer>();
        this.sr.sprite = BrickManager.instance.Sprites[this.hits -1];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hits--;
        if (hits <= 0)
        {
            Destroy(this.gameObject);
        }
        else {
            this.sr.sprite = BrickManager.instance.Sprites[this.hits -1];
        }
    }
}
