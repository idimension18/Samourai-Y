using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum Bus
{
    Rien,
    Beats,
    Sfx,
    Menu
}

public class MainMenu : MonoBehaviour
{
    [SerializeField] public int Play;
    
    [SerializeField] private Slider beatsSlider; 
    [SerializeField] private Slider sfxSlider; 
    [SerializeField] private Slider menuSlider;

    private Bus currentSlider = Bus.Rien;
    
    private FMOD.Studio.Bus sfxBus; //  define a volume controler
    private FMOD.Studio.Bus beatsBus;
    private FMOD.Studio.Bus menuBus;

    void Start()
    {
        beatsBus = FMODUnity.RuntimeManager.GetBus("bus:/Beats");
        sfxBus = FMODUnity.RuntimeManager.GetBus("bus:/SFX");
        menuBus = FMODUnity.RuntimeManager.GetBus("bus:/Menu");
    }

    void Update()
    {
        // Check if the left mouse button (0) is released
        if (Input.GetMouseButtonUp(0))
        {
            switch (currentSlider)
            {
                case Bus.Beats:
                    Debug.Log("Beats");
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Metronome/Itchi"); 
                    currentSlider = Bus.Rien;
                    break;
                case Bus.Sfx:
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Yooooooooooo");
                    currentSlider = Bus.Rien;
                    break;
                case Bus.Menu:
                    currentSlider = Bus.Rien;
                    break;
            }
        }
    }
    
    
    /*
    // Called when the pointer is released from the slider
    public void OnMouseUp()
    {
        switch (currentSlider)
        {
            case Bus.Beats:
                Debug.Log("Beats");
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Metronome/Itchi"); 
                currentSlider = Bus.Rien;
                break;
            case Bus.Sfx:
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Yooooooooooo");
                currentSlider = Bus.Rien;
                break;
            case Bus.Menu:
                currentSlider = Bus.Rien;
                break;
        }
    }
    */
    
    public void ChangeBeatsVolume()
    {
        currentSlider = Bus.Beats;
        beatsBus.setVolume(beatsSlider.value);
        
    }
    
    public void ChangeSfxVolume()
    {
        currentSlider = Bus.Sfx;
        sfxBus.setVolume(sfxSlider.value);
    }
    
    public void ChangeEmbientVolume()
    {
        currentSlider = Bus.Menu;
        menuBus.setVolume(menuSlider.value);
    }
    
    // // get the volume manager
    IEnumerator StartGame()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Start");
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadSceneAsync(Play);
        yield return null;
    }

    public void PlayGame()
    {
        StartCoroutine(StartGame());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
