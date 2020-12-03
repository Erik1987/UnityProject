using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBoss : MonoBehaviour
{
    public SpriteRenderer enemyRenderer;
    private SpriteRenderer playerRenderer;
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed;
    public Animator animator;
    private GameObject playerObj = null;
    private GameObject enemyObj = null;

    public int currentHealth;
    public Slider healthBar;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public float AttackDistance;

    private GameObject fireballGO;
    private GameObject iceSpearGO;

    private Skills skills;
    private Skill fireball;
    private Skill iceBurst;

    // Start is called before the first frame update
    private void Start()
    {
        string PATH = Application.streamingAssetsPath + "/SkillStats.json";
        string data = File.ReadAllText(PATH);
        SkillStats skillStats = SkillStats.CreateFromJson(data);
        fireball = skillStats.boss.Find(skill => skill.name == "Fireball");
        iceBurst = skillStats.boss.Find(skill => skill.name == "Ice Burst");

        fireballGO = Resources.Load<GameObject>("Objects/EnemyFireBall");
        iceSpearGO = Resources.Load<GameObject>("Objects/EnemyIceSpear");
        skills = GetComponent<Skills>();
        rb = this.GetComponent<Rigidbody2D>();

        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("pelaaja");
            if (playerObj != null)
            {
                player = playerObj.transform;
                playerRenderer = playerObj.GetComponent<SpriteRenderer>();
            }
        }

        if (enemyObj == null)
            enemyObj = gameObject;

        timeBtwShots = startTimeBtwShots;

    }

    // Update is called once per frame
    private void Update()
    {
        if (Player.playerLocation != null)
        {
            Vector2 direction = Player.playerLocation - transform.position;
            direction.Normalize();
            movement = direction;

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            healthBar.value = currentHealth;

        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("hpslider"));
            FindObjectOfType<AudioManager>().Stop("bossmusic");
            FindObjectOfType<AudioManager>().Play("bossdeath");
            FindObjectOfType<AudioManager>().Play("bossdeath1");
            FindObjectOfType<AudioManager>().Play("EndMusic");

            GameObject endScreen = Resources.Load("endScreen") as GameObject;
            Instantiate(endScreen);
            //endScreen.SetActive(true);
            Time.timeScale = 0;
        }

        if (currentHealth <= 25 && timeBtwShots <= 0)
        {
            // Fireball
            Vector2 targetDirection = Player.playerLocation - transform.position;
            targetDirection.Normalize();

            skills.ShootProjectilesInCone(
                fireballGO,
                transform.position,
                targetDirection,
                fireball.projectileSpeed,
                fireball.projectileCount,
                fireball.projectileSpread,
                fireball.projectileScale
                );
            FindObjectOfType<AudioManager>().Play("bossfireball");
            timeBtwShots = startTimeBtwShots;
        }
        else if (currentHealth > 25 && !iceBurst.cooldown)
        {
            // Ice Burst
            StartCoroutine(IceBurstCooldown());
            skills.ShootProjectilesInCircle(
                iceSpearGO,
                transform.position,
                iceBurst.projectileSpeed,
                iceBurst.projectileCount,
                iceBurst.projectileScale
                );
                FindObjectOfType<AudioManager>().Play("bossiceburst");
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        IEnumerator IceBurstCooldown()
        {
            iceBurst.cooldown = true;
            yield return new WaitForSeconds(iceBurst.cooldownTime);
            iceBurst.cooldown = false;
        }
    }

    private void FixedUpdate()
    {
        // moveCharacter(movement);

        if (playerObj.transform.position.y > enemyObj.transform.position.y)
        {
            enemyRenderer.sortingOrder = playerRenderer.sortingOrder + 1;
        }
        else if (playerObj.transform.position.y < enemyObj.transform.position.y)
        {
            enemyRenderer.sortingOrder = playerRenderer.sortingOrder - 1;
        }
        else
        {
            enemyRenderer.sortingOrder = playerRenderer.sortingOrder;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("damage1"))
        {
            currentHealth -= 1;
        }

        if (collision.CompareTag("object"))
        {
            
        }

    }

    private void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}