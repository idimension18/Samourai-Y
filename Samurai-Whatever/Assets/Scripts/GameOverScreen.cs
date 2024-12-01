using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] TextMeshProUGUI pointsScore;

    public void AfficheScore(int score)
    {
        gameObject.SetActive(true);
        pointsScore.text = "Score : " + score.ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
