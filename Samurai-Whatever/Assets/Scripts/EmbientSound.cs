using UnityEngine;

public class EmbientSound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Wind");
    }
}
