using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{

    public Text ScoreText;
    public int score = 0;
    public int max;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerSlash.OnParry += addScore;
        score = 0;
    }

    public void addScore()
    {
        score += 1;
        Debug.Log("Score ?");
    }

    public void updateScore()
    {
        ScoreText.text = "Score " + score;
    }

    // Update is called once per frame
    void Update()
    {
        updateScore(); 
    }

    void OnDestroy()
    {
        PlayerSlash.OnParry -= addScore;
    }
}
