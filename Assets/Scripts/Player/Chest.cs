using System.Collections;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private GameObject player;
    private bool opened;
    public int lootCount = 50;
    private GameObject coin;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("pelaaja");
        opened = false;
        coin = Resources.Load<GameObject>("Treasures/Coin");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            OpenChest();
            StartCoroutine(DropLoot());
        }

        if (player.transform.position.y > gameObject.transform.position.y)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 11;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 8;
        }
    }

    private void OpenChest()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (!opened && distance < 2f)
        {
            opened = true;
            gameObject.GetComponent<Animator>().SetTrigger("open");
        }
    }

    private IEnumerator DropLoot()
    {
        yield return new WaitForSeconds(0.5f);

        Vector2 chestCenterPosition = transform.position;
        chestCenterPosition.y -= 0.5f;

        for (int i = 0; i < lootCount; i++)
        {
            GameObject loot = Instantiate(coin, chestCenterPosition, Quaternion.identity);
            loot.GetComponent<SpriteRenderer>().sortingOrder = 12;

            Vector2 startPoint = chestCenterPosition;
            Vector2 endPoint = chestCenterPosition;

            System.Random random = new System.Random();
            float randomX = (float)(random.NextDouble() * 2);
            float randomY = (float)(random.NextDouble() + 1.0);
            if (random.Next(0, 2) == 1)
            {
                randomX *= -1;
            }
            randomY *= -1;

            endPoint.x += randomX;
            endPoint.y += randomY;

            float totalMovementTime = 0.15f;
            float currentMovementTime = 0f;
            float singleMovementTime = 0.01f;
            while (currentMovementTime < totalMovementTime)
            {
                if (loot)
                {
                    currentMovementTime += singleMovementTime;
                    loot.transform.position = Vector2.Lerp(startPoint, endPoint, currentMovementTime / totalMovementTime);
                    yield return new WaitForSeconds(singleMovementTime);
                }
                else
                {
                    float timeLeft = totalMovementTime - currentMovementTime;
                    yield return new WaitForSeconds(timeLeft);
                    break;
                }
            }

            if (loot)
            {
                loot.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
        }
    }
}