using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private LevelScript[] _levels;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < _levels.Length; i++)
        {
            _levels[i].LaunchLevel();
            Debug.Log("Level "+ (i+1).ToString()+" begins");
        }
    }

}
