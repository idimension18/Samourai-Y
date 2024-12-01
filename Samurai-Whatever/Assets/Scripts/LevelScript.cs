using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptaleObject", menuName = "Scriptable Objects/ScriptaleObject")]
public class LevelScript : ScriptableObject
{
    [SerializeField] private List<EnemyScript> _enemies;
    [SerializeField] private Enemy enemyPrefab;

    [Tooltip("Niveau terminé ou non")]
    [SerializeField] private bool _clear;
    [SerializeField] private int _dist;


    public void LaunchLevel()
    {
        int n;
        for(n = 0; n< _enemies.Count; n++)
        {
            if (_enemies[n].right)
            {
                Instantiate(enemyPrefab, _dist * Vector2.right, Quaternion.identity);
            }
            else Instantiate(enemyPrefab, _dist * Vector2.left, Quaternion.identity);
        }
        if (_clear)
        {

        }
    }
}


[Serializable] public class EnemyScript
{
    [Tooltip("is false, then comes from left")]
    [SerializeField] public bool right { get; private set; }
    [SerializeField] public float[] _timings {  get; private set; }
}
