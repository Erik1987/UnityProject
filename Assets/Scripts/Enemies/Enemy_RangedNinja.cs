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
    public float projectileSpeed = 15;

    private float timeBtwShots;
    public float startTimeBtwShots;

    // Start is called before the first frame update
    private void Start()
    {
        kunai = Resources.Load<GameObject>("Objects/EnemyKunai");

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
        }

        if (timeBtwShots <= 0)
        {
            Vector2 targetDirection = Player.playerLocation - transform.position;
            targetDirection.Normalize();
            float textureAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

            GameObject newEnemyProjectile = Instantiate(kunai, transform.position, Quaternion.Euler(0, 0, textureAngle));
            newEnemyProjectile.GetComponent<Rigidbody2D>().velocity = targetDirection * projectileSpeed;
            Destroy(newEnemyProjectile, 2f);

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