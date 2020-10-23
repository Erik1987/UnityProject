using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RangedAttack : MonoBehaviour
{
    // Fireball
    private GameObject fireBall;

    public float fireBallSpeed = 15;
    public float fireballCooldownTime = 0.2f;
    public bool fireballCooldown;

    // Ice Burst
    private GameObject iceSpear;

    public float iceBurstSpearSpeed = 12;
    public int iceBurstSpearCount = 12;
    public float iceBurstCooldownTime = 1f;
    public bool iceBurstCooldown;

    // Ice Spiral
    public float iceSpiralSpearSpeed = 12;

    public int iceSpiralSpearCount = 18;
    public int iceSpiralRounds = 2;
    public float iceSpiralSpearFrequence = 0.05f;
    public float iceSpiralCooldownTime = 3f;
    public bool iceSpiralCooldown;

    // Lightning Sigil
    private GameObject lightning;

    public int lightningSigilCount = 3;
    public float lightningSigilDuration = 2f;
    public float lightningSigilCooldownTime = 2f;
    public bool lightningSigilCooldown;

    // Dash
    public float dashDistance = 3f;

    public float dashCooldownTime = 1f;
    public bool dashCooldown;

    private void Start()
    {
        fireBall = Resources.Load<GameObject>("Objects/FireBall");
        iceSpear = Resources.Load<GameObject>("Objects/IceSpear");
        lightning = Resources.Load<GameObject>("Objects/Lightning");

        SceneManager.activeSceneChanged += ResetCooldowns;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !fireballCooldown)
        {
            Fireball();
            StartCoroutine(FireballCooldown());
            FindObjectOfType<AudioManager>().Play("Fireball");
        }

        if (Input.GetMouseButtonDown(1) && !iceBurstCooldown)
        {
            IceBurst();
            StartCoroutine(IceBurstCooldown());
        }

        if (Input.GetKeyDown("1") && !iceSpiralCooldown)
        {
            StartCoroutine(IceSpiral());
            StartCoroutine(IceSpiralCooldown());
        }

        if (Input.GetKeyDown("2") && !lightningSigilCooldown)
        {
            LightningSigil();
            StartCoroutine(LightningSigilCooldown());
        }

        if (Input.GetKeyDown("space") && !dashCooldown)
        {
            StartCoroutine(Dash());
            StartCoroutine(DashCooldown());
        }
    }

    public void ResetCooldowns(Scene current, Scene next)
    {
        fireballCooldown = false;
        iceBurstCooldown = false;
        iceSpiralCooldown = false;
        lightningSigilCooldown = false;
        dashCooldown = false;
    }

    private void Fireball()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = (Input.mousePosition - pos).normalized;
        float textureAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        GameObject newFire = Instantiate(fireBall, transform.position, Quaternion.Euler(0, 0, textureAngle));

        newFire.GetComponent<Rigidbody2D>().velocity = dir * fireBallSpeed;
        Destroy(newFire, 2f);
    }

    private IEnumerator FireballCooldown()
    {
        fireballCooldown = true;
        yield return new WaitForSeconds(fireballCooldownTime);
        fireballCooldown = false;
    }

    private void IceBurst()
    {
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
            GameObject newIceSpear = Instantiate(iceSpear, transform.position, Quaternion.Euler(0, 0, textureAngle));

            newIceSpear.GetComponent<Rigidbody2D>().velocity = new Vector2(iceSpearDir.x, iceSpearDir.y) * iceBurstSpearSpeed;

            angle += angleStep;
        }
    }

    private IEnumerator IceBurstCooldown()
    {
        iceBurstCooldown = true;
        yield return new WaitForSeconds(iceBurstCooldownTime);
        iceBurstCooldown = false;
    }

    private IEnumerator IceSpiral()
    {
        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
        for (int j = 0; j < iceSpiralRounds; j++)
        {
            float angleStep = 360f / iceSpiralSpearCount;
            float angle = 0f;
            for (int i = 0; i < iceSpiralSpearCount; i++)
            {
                float dirX = pos.x + Mathf.Sin(angle * Mathf.PI / 180);
                float dirY = pos.y + Mathf.Cos(angle * Mathf.PI / 180);

                Vector2 iceSpearV = new Vector2(dirX, dirY);
                Vector2 iceSpearDir = (iceSpearV - pos).normalized;

                float textureAngle = Mathf.Atan2(iceSpearDir.y, iceSpearDir.x) * Mathf.Rad2Deg;
                GameObject newIceSpear = Instantiate(iceSpear, transform.position, Quaternion.Euler(0, 0, textureAngle));

                newIceSpear.GetComponent<Rigidbody2D>().velocity = new Vector2(iceSpearDir.x, iceSpearDir.y) * iceSpiralSpearSpeed;

                angle += angleStep;

                yield return new WaitForSeconds(iceSpiralSpearFrequence);
            }
        }
    }

    private IEnumerator IceSpiralCooldown()
    {
        iceSpiralCooldown = true;
        yield return new WaitForSeconds(iceSpiralCooldownTime);
        iceSpiralCooldown = false;
    }

    private void LightningSigil()
    {
        float angleStep = 360f / lightningSigilCount;
        float angle = 0f;
        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
        float randomAngle = Random.Range(0, 180);

        for (int i = 0; i < lightningSigilCount; i++)
        {
            float dirX = pos.x + Mathf.Sin(angle * Mathf.PI / 180);
            float dirY = pos.y + Mathf.Cos(angle * Mathf.PI / 180);

            Vector2 lightningV = new Vector2(dirX, dirY);
            Vector2 lightningDir = (lightningV - pos).normalized;

            float textureAngle = Mathf.Atan2(lightningDir.y, lightningDir.x) * Mathf.Rad2Deg - randomAngle;
            GameObject newLightning = Instantiate(lightning, transform.position, Quaternion.Euler(0, 0, textureAngle + 180f));

            Destroy(newLightning, lightningSigilDuration);

            angle += angleStep;
        }
    }

    private IEnumerator LightningSigilCooldown()
    {
        lightningSigilCooldown = true;
        yield return new WaitForSeconds(lightningSigilCooldownTime);
        lightningSigilCooldown = false;
    }

    private IEnumerator Dash()
    {
        Player player = GetComponent<Player>();
        player.immune = true;
        Vector2 moveDir = GetComponent<PlayerMovement>().movement.normalized;
        Vector2 startPoint = transform.position;
        Vector2 endPoint = startPoint + moveDir * dashDistance;

        float totalMovementTime = 0.15f;
        float currentMovementTime = 0f;
        float singleMovementTime = totalMovementTime / 10;
        while (currentMovementTime < totalMovementTime)
        {
            currentMovementTime += singleMovementTime;
            RaycastHit2D colliderCheck = Physics2D.Raycast(startPoint, moveDir, dashDistance);
            if (colliderCheck.collider == null || colliderCheck.collider.CompareTag("pelaaja") || colliderCheck.collider.CompareTag("enemy"))
            {
                startPoint = Vector2.Lerp(startPoint, endPoint, currentMovementTime / totalMovementTime);
                transform.position = startPoint;
                yield return new WaitForSeconds(singleMovementTime);
                continue;
            }
            else
            {
                break;
            }
        }
        yield return new WaitForSeconds(0.2f);
        player.immune = false;
    }

    private IEnumerator DashCooldown()
    {
        dashCooldown = true;
        yield return new WaitForSeconds(dashCooldownTime);
        dashCooldown = false;
    }
}