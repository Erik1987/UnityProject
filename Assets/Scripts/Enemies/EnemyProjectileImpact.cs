using UnityEngine;

public class EnemyProjectileImpact : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("enemy") && !collision.collider.CompareTag("damageP"))
            Destroy(gameObject);
    }
}