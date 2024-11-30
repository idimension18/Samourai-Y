using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector3 dir = (Player.pos - transform.position).normalized;
        rb.linearVelocity = dir * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {  
        Player player;
        if (collision.gameObject.TryGetComponent(out player))
        {
            Debug.Log("GAME OVER");
            //TODO Game Over
            Application.Quit();
        }
    
    }
}
