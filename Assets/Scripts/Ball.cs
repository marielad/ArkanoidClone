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
}
