using UnityEngine;

public class ProjectileImpact : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("pelaaja") && !collision.collider.CompareTag("damage1"))
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("pelaaja") && !collision.CompareTag("damage1"))
            Destroy(gameObject);
    }
}