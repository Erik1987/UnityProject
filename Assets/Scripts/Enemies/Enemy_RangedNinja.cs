using System.IO;
using UnityEngine;

public class Enemy_RangedNinja : MonoBehaviour
{
    public ParticleSystem deathParticle;
    public SpriteRenderer enemyRenderer;
    private SpriteRenderer playerRenderer;
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed;
    public Animator animator;
    private GameObject playerObj = null;
    private GameObject enemyObj = null;
    private Enemy enemy = null;

    private GameObject kunai;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private Skills skills;
    private Skill ninjaKnife;

    // Start is called before the first frame update
    private void Start()
    {
        string PATH = Application.streamingAssetsPath + "/SkillStats.json";
        string data = File.ReadAllText(PATH);
        SkillStats skillStats = SkillStats.CreateFromJson(data);
        ninjaKnife = skillStats.rangedNinja.Find(skill => skill.name == "Ninja Knife");

        kunai = Resources.Load<GameObject>("Objects/EnemyKunai");
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
        enemy = enemyObj.GetComponent<Enemy>();

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
        }

        if (enemy.currentHealth <= 0)
        {
            UnityEngine.Debug.Log("DIE!!!!!");
            Instantiate(deathParticle, enemyObj.transform.position, enemyObj.transform.rotation);
            FindObjectOfType<AudioManager>().Play("EnemyDeath");
        }

        if (timeBtwShots <= 0)
        {
            // Kitchen knife
            Vector2 targetDirection = Player.playerLocation - transform.position;
            targetDirection.Normalize();
            skills.ShootProjectileInDirection(
                kunai,
                transform.position,
                targetDirection,
                ninjaKnife.projectileSpeed
                );
            FindObjectOfType<AudioManager>().Play("enemyknives");
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (playerObj != null)
        {
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
    }

    private void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}