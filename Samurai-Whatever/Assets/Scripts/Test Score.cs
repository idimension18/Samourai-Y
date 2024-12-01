using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;

public class TestScore : MonoBehaviour
{

    public Score score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.P))
        {
            score.addScore(1);
        } 
    }
}
