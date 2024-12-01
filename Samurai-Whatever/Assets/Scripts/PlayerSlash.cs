using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent (typeof(CircleCollider2D))]
public class PlayerSlash : MonoBehaviour
{
    static public event Action OnParry;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Bullet bullet;
        if (collision.gameObject.TryGetComponent(out bullet))
        {

            OnParry.Invoke();
            Debug.Log(Player.score);

            Debug.Log("destroyed");
            Destroy(bullet.gameObject);
        }
    }
}
