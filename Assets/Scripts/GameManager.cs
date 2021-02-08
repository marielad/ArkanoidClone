using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameStarted { get; set; }

    void Awake()
    {
        GameManager.instance = this;
    }

    private void Start()
    {
        Screen.SetResolution(540,960,false);
    }
}
