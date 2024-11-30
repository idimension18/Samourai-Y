using System.Collections;
using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]
public class PlayerSlash : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Bullet bullet;
        if (collision.gameObject.TryGetComponent(out bullet))
        {
            Player.score++;
            Debug.Log(Player.score);

            Debug.Log("destroyed");
            Destroy(bullet.gameObject);
        }
    }
}
