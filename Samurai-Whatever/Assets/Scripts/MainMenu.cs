using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public int Play;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(Play);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
