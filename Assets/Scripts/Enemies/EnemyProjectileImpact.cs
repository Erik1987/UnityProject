using UnityEngine;

public class EnemyProjectileImpact : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("enemy") &&
            !collision.collider.CompareTag("super-enemy") &&
            !collision.collider.CompareTag("damageP") &&
            !collision.collider.CompareTag("Coin") &&
            !collision.collider.CompareTag("Health") &&
            !collision.collider.CompareTag("StoryNote") &&
            !collision.collider.CompareTag("StoryNote1") &&
            !collision.collider.CompareTag("StoryNote2") &&
            !collision.collider.CompareTag("StoryNote3") &&
            !collision.collider.CompareTag("StoryNote4") &&
            !collision.collider.CompareTag("water") &&
            !collision.collider.CompareTag("waterFull"))
            Destroy(gameObject);
    }
}