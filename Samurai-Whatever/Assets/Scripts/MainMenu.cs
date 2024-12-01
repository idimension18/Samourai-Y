using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public int Play;

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
