using Assets.Scripts.Player;
using Pathfinding;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int currentHealth;
    public bool immune;
    public int currentMana;
    public string gameMode;
    public int coins = 0;
    private static bool IsDead = false;
    public string currentSceneName;
    public TrackedScenes trackedScenes = new TrackedScenes();
   
    public GameObject GameOver;

    public static Vector3 playerLocation;

    // Start is called before the first frame update
    private void Start()
    {

        immune = false;
        // this defines players starting stats:
        // added game modes "Easy, Medium, Hard"
        gameMode = "Easy";
        if (gameMode == "Easy")
        {
            currentHealth = 10;
            currentMana = 10;
        }
        else if (gameMode == "Medium")
        {
            currentHealth = 5;
            currentMana = 5;
        }
        else if (gameMode == "Hard")
        {
            currentHealth = 3;
            currentMana = 3;
        }
        else
        {
            Debug.Log("Please, select the GameMode!");
            gameMode = "GrandArchitect";
            Debug.Log("GrandArchitect mode initialized!");
            currentHealth = 100;
            currentMana = 100;
        }
    }

    private void Update()
    {
        playerLocation = gameObject.transform.position;
        AIDestinationSetter.targetLocation = playerLocation;
        currentSceneName = SceneManager.GetActiveScene().name;

    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "damageP")
        {
            if (!immune)
            {
                immune = true;
                currentHealth -= 1;

                GetComponent<Animator>().SetBool("takesDamage", true);
                StartCoroutine(DamageAnimationTimer());
                FindObjectOfType<AudioManager>().Play("TakeDamage");
            }
            if (currentHealth <= 0)
            {
                FindObjectOfType<AudioManager>().Stop("EndMusic");
                FindObjectOfType<AudioManager>().Stop("bossmusic");
                FindObjectOfType<AudioManager>().Stop("Theme");
                FindObjectOfType<AudioManager>().Stop("ShopMusic");
                FindObjectOfType<AudioManager>().Play("gameover");
                GameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
                IsDead = true;
            }
        }
        else if (collision.gameObject.tag == "super-enemy")
        {
            if (!immune)
            {
                immune = true;
                currentHealth -= 2;

                GetComponent<Animator>().SetBool("takesDamage", true);
                StartCoroutine(DamageAnimationTimer());
                FindObjectOfType<AudioManager>().Play("TakeDamage");
            }
            if (currentHealth <= 0)
            {

                FindObjectOfType<AudioManager>().Play("gameover");
                FindObjectOfType<AudioManager>().Stop("Theme");
                FindObjectOfType<AudioManager>().Stop("ShopMusic");
                FindObjectOfType<AudioManager>().Stop("bossmusic");

                GameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
                IsDead = true;
            }
        }
    }

    private IEnumerator DamageAnimationTimer()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetBool("takesDamage", false);
        immune = false;
    }
    public void Save()
    {
        SaveSystem.SavePlayer(this);
        Debug.Log("Player Saved ");
    }
    public void Load()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        
        currentSceneName = data.sceneName;
        SceneManager.LoadScene($"{currentSceneName}");
        currentHealth = data.health;
        currentMana = data.mana;
        coins = data.gold;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        Debug.Log("Player Loaded ");
    }

    public void addHealthBurger()
    {
        currentHealth = 10;
    }

    public void addHealthPlant()
    {
        if(currentHealth < 7)
        {
            currentHealth += 3;
        }
        else
        {
            currentHealth = 10;
        }
    }

   
}