using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public GameObject brickPrefab;
    public Sprite[] Sprites;

    public List<int[,]> Levels { get; set; }

    public static BrickManager instance;

    void Awake()
    {
        BrickManager.instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.Levels = this.LoadLevels();
    }

    private List<int[,]> LoadLevels()
    {
        //int[,] currentLevel = new int[7,7];
        //for (int i = 0; i < length; i++)
        //{
        //    int random = ;
        //}
    }

}
