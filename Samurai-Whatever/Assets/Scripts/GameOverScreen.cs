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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
