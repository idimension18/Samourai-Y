using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void UpdateScore()
    {
        Player.score++;
    }

    private void OnDestroy()
    {
        UpdateScore();
    }
}
