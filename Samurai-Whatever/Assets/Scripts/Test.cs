using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private FMOD.Studio.Bus randomBus;   //  define a volume controler
    void Start()
    {
        randomBus = FMODUnity.RuntimeManager.GetBus("bus:/SFX");   // get the volume manager

        randomBus.setVolume(0.3f);  // set the new volume     (between 0 and 1)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
