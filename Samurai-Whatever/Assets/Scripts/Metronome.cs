using UnityEngine;

public class Metronome : MonoBehaviour
{
    public static Metronome instance;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }
}
