using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptaleObject", menuName = "Scriptable Objects/ScriptaleObject")]
public class LevelScript : ScriptableObject
{
    [SerializeField] private List<EnemyScript> _enemies;
    [SerializeField] private Enemy enemyPrefab;

    [Tooltip("Niveau termin� ou non")]
    [SerializeField] private bool _clear;
    [SerializeField] private int _dist;


    public void LaunchLevel()
    {
        int n;
        for(n = 0; n< _enemies.Count; n++)
        {
            if (_enemies[n].getRight())
            {
                if (Instantiate(enemyPrefab, _dist * Vector2.right + Vector2.up * 0.7f, Quaternion.identity).TryGetComponent(out Enemy newEnemy))
                {
                    newEnemy.SetLevel(this);
                }
            }

            else 
            {
                if (Instantiate(enemyPrefab, _dist * Vector2.right + Vector2.up * 0.7f, Quaternion.identity).TryGetComponent(out Enemy newEnemy))
                {
                    newEnemy.SetLevel(this);
                }
            }
        }
    }
    [SerializeField] private int bpm;

    public int getBPM()
    {
        return bpm;
    }

    public int getNbrEnnemies()
    {
        return _enemies.ToArray().Length;
    }

    public List<EnemyScript> getEnemyList()
    {
        return _enemies;
    } 
}


[Serializable] public class EnemyScript
{
    [Tooltip("is false, then comes from left")]
    [SerializeField] private bool _right;
    [SerializeField] private float[] _timings;

    public float[] getTimings()
    {
        return _timings;
    }

    public bool getRight()
    {
        return _right;
    }
}

