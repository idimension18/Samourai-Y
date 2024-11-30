using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text ScoreText;
    public int score = 0;
    public int max;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
    }

    public void addScore(int newScore)
    {
        score += newScore;
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
}
