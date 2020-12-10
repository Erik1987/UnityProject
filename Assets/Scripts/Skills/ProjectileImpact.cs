using UnityEngine;

public class ProjectileImpact : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("pelaaja") && 
            !collision.collider.CompareTag("damage1") &&
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

    //waterfull kaatoi kaupan testausvaiheessa joten väliaikaisesti kommenteissa -v

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("pelaaja") &&
            !collision.CompareTag("damage1") &&
            !collision.CompareTag("Coin") &&
            !collision.CompareTag("Health") &&
            !collision.CompareTag("StoryNote") &&
            !collision.CompareTag("StoryNote1") &&
            !collision.CompareTag("StoryNote2") &&
            !collision.CompareTag("StoryNote3") &&
            !collision.CompareTag("StoryNote4") &&
            !collision.CompareTag("water") &&
            !collision.CompareTag("waterFull"))
            Destroy(gameObject);
    }
}