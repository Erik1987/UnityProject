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
    private int noteNum;
    public GameObject[] noteList;

    private static bool note0hasSpawned = false;
    private static bool note1hasSpawned = false;
    private static bool note2hasSpawned = false;
    private static bool note3hasSpawned = false;
    private static bool note4hasSpawned = false;

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
        else if (randomNumber >= 98 && note0hasSpawned == false)
        {
            noteNum = 0;
            Instantiate(noteList[noteNum], transform.position, Quaternion.identity);
            note0hasSpawned = true;
            UnityEngine.Debug.Log("Note 1 found!");

        }
        else if (randomNumber < 98 && randomNumber >= 96 && note1hasSpawned == false)
        {
            noteNum = 1;
            Instantiate(noteList[noteNum], transform.position, Quaternion.identity);
            note1hasSpawned = true;
            UnityEngine.Debug.Log("Note 2 found!");

        }
        else if (randomNumber < 96 && randomNumber >= 94 && note2hasSpawned == false)
        {
            noteNum = 2;
            Instantiate(noteList[noteNum], transform.position, Quaternion.identity);
            note2hasSpawned = true;
            UnityEngine.Debug.Log("Note 3 found!");

        }
        else if (randomNumber < 94 && randomNumber >= 92 && note3hasSpawned == false)
        {
            noteNum = 3;
            Instantiate(noteList[noteNum], transform.position, Quaternion.identity);
            note3hasSpawned = true;
            UnityEngine.Debug.Log("Note 4 found!");

        }
        else if (randomNumber < 92 && randomNumber >= 90 && note4hasSpawned == false)
        {
            noteNum = 4;
            Instantiate(noteList[noteNum], transform.position, Quaternion.identity);
            note4hasSpawned = true;
            UnityEngine.Debug.Log("Note 5 found!");

        }
    }
}