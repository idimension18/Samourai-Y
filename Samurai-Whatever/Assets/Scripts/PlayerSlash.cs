using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]
public class PlayerSlash : MonoBehaviour
{
    [SerializeField] private KeyCode key;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Bullet bullet;
        if (!collision.gameObject.TryGetComponent<Bullet>(out bullet)) return;
        if(Input.GetKeyDown(key)) {
            Destroy(bullet);
        }
    }

}
