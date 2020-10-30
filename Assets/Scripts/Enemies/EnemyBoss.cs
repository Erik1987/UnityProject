using System.Collections;
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

    private GameObject fireBall;
    public float fireBallSpeed = 15;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public float AttackDistance;

    private GameObject iceSpear;
    public float iceBurstSpearSpeed = 12;
    public int iceBurstSpearCount = 12;
    public float iceBurstCooldownTime = 1f;
    public bool iceBurstCooldown = false;

    // Start is called before the first frame update
    private void Start()
    {
        fireBall = Resources.Load<GameObject>("Objects/EnemyFireball");
        iceSpear = Resources.Load<GameObject>("Objects/EnemyIceSpear");

        rb = this.GetComponent<Rigidbody2D>();

        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("pelaaja");
            player = playerObj.transform;
            playerRenderer = playerObj.GetComponent<SpriteRenderer>();
        }

        if (enemyObj == null)
            enemyObj = gameObject;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 direction = Player.playerLocation - transform.position;
        direction.Normalize();
        movement = direction;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        healthBar.value = currentHealth;

        if (currentHealth == 0)
        {
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("hpslider"));
        }

        if (timeBtwShots <= 0)
        {
            Vector2 targetDirection = Player.playerLocation - transform.position;
            targetDirection.Normalize();
            float textureAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

            GameObject newEnemyFire = Instantiate(fireBall, transform.position, Quaternion.Euler(0, 0, textureAngle));
            newEnemyFire.GetComponent<Rigidbody2D>().velocity = targetDirection * fireBallSpeed;
            Destroy(newEnemyFire, 2f);

            timeBtwShots = startTimeBtwShots;
        }
        else if (Vector2.Distance(Player.playerLocation, transform.position) > AttackDistance && !iceBurstCooldown)
        {
            StartCoroutine(IceBurstCooldown());

            float angleStep = 360f / iceBurstSpearCount;
            float angle = 0f;
            Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);

            for (int i = 0; i < iceBurstSpearCount; i++)
            {
                float dirX = pos.x + Mathf.Sin(angle * Mathf.PI / 180);
                float dirY = pos.y + Mathf.Cos(angle * Mathf.PI / 180);

                Vector2 iceSpearV = new Vector2(dirX, dirY);
                Vector2 iceSpearDir = (iceSpearV - pos).normalized;

                float textureAngle = Mathf.Atan2(iceSpearDir.y, iceSpearDir.x) * Mathf.Rad2Deg;
                GameObject newEnemyIceSpear = Instantiate(iceSpear, transform.position, Quaternion.Euler(0, 0, textureAngle));

                newEnemyIceSpear.GetComponent<Rigidbody2D>().velocity = new Vector2(iceSpearDir.x, iceSpearDir.y) * iceBurstSpearSpeed;

                angle += angleStep;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        IEnumerator IceBurstCooldown()
        {
            iceBurstCooldown = true;
            yield return new WaitForSeconds(iceBurstCooldownTime);
            iceBurstCooldown = false;
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
    }

    private void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}