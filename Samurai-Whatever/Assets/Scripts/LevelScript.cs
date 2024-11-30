using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptaleObject", menuName = "Scriptable Objects/ScriptaleObject")]
public class LevelScript : ScriptableObject
{
    [SerializeField] private List<EnemyScript> _enemies;
    [Tooltip("Niveau terminé ou non")]
    [SerializeField] private bool _clear;
}


[Serializable] public class EnemyScript
{
    [Tooltip("is false, then comes from left")]
    [SerializeField] private bool _right;
    [SerializeField] private float[] _timings;
}