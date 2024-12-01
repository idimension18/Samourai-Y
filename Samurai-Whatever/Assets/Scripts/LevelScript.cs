using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptaleObject", menuName = "Scriptable Objects/ScriptaleObject")]
public class LevelScript : ScriptableObject
{
    [SerializeField] private List<EnemyScript> _enemies;
    [Tooltip("Niveau terminé ou non")]
    [SerializeField] private bool _clear;
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

