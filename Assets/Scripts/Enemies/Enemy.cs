using System.Collections;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currentHealth;
    public bool immune;
    public int currentMana;
    public GameObject tweetPrefab;
    private bool tweetShown;
    public GameObject coinDrop;
    public GameObject memoDropChance;

    // Start is called before the first frame update
    private void Start()
    {
        immune = false;
        tweetShown = false;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            DropItems();
            TwitterApiProvider.canNextTweetBeShown = true;
        }
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("damage1"))
        {
            if (!immune)
            {
                immune = true;
                currentHealth -= 1;

                GetComponent<Animator>().SetBool("takesDamage", true);
                StartCoroutine(DamageAnimationTimer());
            }
            //ShowTweetAndRemoveFromPoolAfterUse();
        }
    }

    private IEnumerator DamageAnimationTimer()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<Animator>().SetBool("takesDamage", false);
        immune = false;
    }

    private void ShowTweetAndRemoveFromPoolAfterUse()
    {
        var tweets = TwitterApiProvider.publicTweets;
        if (tweets.Any() && !tweetShown && TwitterApiProvider.canNextTweetBeShown)
        {
            TwitterApiProvider.canNextTweetBeShown = false;

            var randomNumber = new System.Random();
            var number = randomNumber.Next(0, tweets.Count);
            tweetPrefab.GetComponent<TMPro.TextMeshPro>().text = tweets[number].text;
            var renderer = tweetPrefab.GetComponent<MeshRenderer>();
            renderer.sortingOrder = 1000;
            renderer.sortingLayerID = SortingLayer.GetLayerValueFromName("Default");

            tweets.RemoveAt(number);
            tweetShown = true;

            Destroy(Instantiate(tweetPrefab, transform), 5f);
            Invoke(nameof(ResetCanNextTweetBeShown), 5f);
        }
    }

    private void ResetCanNextTweetBeShown()
    {
        TwitterApiProvider.canNextTweetBeShown = true;
    }

    private void DropItems()
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(0, 100);

        if (randomNumber >= 0 && randomNumber <= 20)
        {
            Instantiate(coinDrop, transform.position, Quaternion.identity);
        }
        else if (randomNumber >= 95)
        {
            Instantiate(memoDropChance, transform.position, Quaternion.identity);
        }
    }
}