using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RangedAttack : MonoBehaviour
{
    public GameObject fireballGO;
    public GameObject iceSpearGO;
    public GameObject lightningGO;
    private Skills skills;
    private Skill fireball;
    private Skill iceBurst;
    private Skill iceSpiral;
    private Skill lightningSigil;
    private Skill dash;

    private void Start()
    {
        string PATH = Application.streamingAssetsPath + "/SkillStats.json";
        string data = File.ReadAllText(PATH);
        SkillStats skillStats = SkillStats.CreateFromJson(data);
        fireball = skillStats.player.Find(skill => skill.name == "Fireball");
        iceBurst = skillStats.player.Find(skill => skill.name == "Ice Burst");
        iceSpiral = skillStats.player.Find(skill => skill.name == "Ice Spiral");
        lightningSigil = skillStats.player.Find(skill => skill.name == "Lightning Sigil");
        dash = skillStats.player.Find(skill => skill.name == "Dash");

        fireballGO = Resources.Load<GameObject>("Objects/FireBall");
        iceSpearGO = Resources.Load<GameObject>("Objects/IceSpear");
        lightningGO = Resources.Load<GameObject>("Objects/Lightning");

        SceneManager.activeSceneChanged += ResetCooldowns;

        skills = GetComponent<Skills>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !fireball.cooldown && !PauseMenu.IsPaused)
        {
            GetComponent<Animator>().SetTrigger("Casts");
            skills.ShootProjectilesInCone(
                fireballGO,
                transform.position,
                (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized,
                fireball.projectileSpeed,
                fireball.projectileCount,
                fireball.projectileSpread,
                fireball.projectileScale
                );
            FindObjectOfType<AudioManager>().Play("Fireball");
            StartCoroutine(FireballCooldown());
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (iceBurst.activated && !iceBurst.cooldown)
            {
                GetComponent<Animator>().SetTrigger("Casts");
                skills.ShootProjectilesInCircle(
                    iceSpearGO,
                    transform.position,
                    iceBurst.projectileSpeed,
                    iceBurst.projectileCount,
                    iceBurst.projectileScale
                    );
                StartCoroutine(IceBurstCooldown());
                FindObjectOfType<AudioManager>().Play("IceBurst");
            }
            
            if (iceSpiral.activated && !iceSpiral.cooldown)
            {
                GetComponent<Animator>().SetTrigger("Casts");
                StartCoroutine(IceSpiral());
                StartCoroutine(IceSpiralCooldown());
            }

            if (lightningSigil.activated && !lightningSigil.cooldown)
            {
                GetComponent<Animator>().SetTrigger("Casts");
                LightningSigil();
                StartCoroutine(LightningSigilCooldown());
                FindObjectOfType<AudioManager>().Play("LightningAtt");
            }

            if (dash.activated && !dash.cooldown)
            {
                GetComponent<Animator>().SetTrigger("Casts");
                StartCoroutine(Dash());
                StartCoroutine(DashCooldown());
                FindObjectOfType<AudioManager>().Play("Dash");
            }
        }
    }

    public void ActivateSkill(string name)
    {
        fireball.projectileCount = 1;
        iceBurst.activated = false;
        iceSpiral.activated = false;
        lightningSigil.activated = false;
        dash.activated = false;

        switch (name)
        {
            case "Fireball":
                fireball.projectileCount = 5;
                break;
            case "Ice Burst":
                iceBurst.activated = true;
                break;
            case "Ice Spiral":
                iceSpiral.activated = true;
                break;
            case "Lightning Sigil":
                lightningSigil.activated = true;
                break;
            case "Dash":
                dash.activated = true;
                break;
            default:
                Debug.Log("Cannot find a skill matching string: " + name);
                break;
        }
    }


    public void ResetCooldowns(Scene current, Scene next)
    {
        fireball.cooldown = false;
        iceBurst.cooldown = false;
        iceSpiral.cooldown = false;
        lightningSigil.cooldown = false;
        dash.cooldown = false;

        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("damage1");
        foreach (GameObject projectile in projectiles)
        {
            Destroy(projectile);
        }
    }

    private IEnumerator FireballCooldown()
    {
        fireball.cooldown = true;
        yield return new WaitForSeconds(fireball.cooldownTime);
        fireball.cooldown = false;
    }

    private IEnumerator IceBurstCooldown()
    {
        iceBurst.cooldown = true;
        yield return new WaitForSeconds(iceBurst.cooldownTime);
        iceBurst.cooldown = false;
    }

    private IEnumerator IceSpiral()
    {
        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
        for (int j = 0; j < iceSpiral.projectileWaves; j++)
        {
            float angleStep = 360f / iceSpiral.projectileCount;
            float angle = 0f;
            for (int i = 0; i < iceSpiral.projectileCount; i++)
            {
                float dirX = pos.x + Mathf.Sin(angle * Mathf.PI / 180);
                float dirY = pos.y + Mathf.Cos(angle * Mathf.PI / 180);

                Vector2 iceSpearV = new Vector2(dirX, dirY);
                Vector2 iceSpearDir = (iceSpearV - pos).normalized;
                FindObjectOfType<AudioManager>().Play("IceSpiral");

                float textureAngle = Mathf.Atan2(iceSpearDir.y, iceSpearDir.x) * Mathf.Rad2Deg;
                GameObject newIceSpear = Instantiate(iceSpearGO, transform.position, Quaternion.Euler(0, 0, textureAngle));
                newIceSpear.transform.localScale *= iceSpiral.projectileScale;
                newIceSpear.GetComponent<Rigidbody2D>().velocity = new Vector2(iceSpearDir.x, iceSpearDir.y) * iceSpiral.projectileSpeed;

                angle += angleStep;

                yield return new WaitForSeconds(iceSpiral.projectileFrequence);
            }
        }
    }

    private IEnumerator IceSpiralCooldown()
    {
        iceSpiral.cooldown = true;
        yield return new WaitForSeconds(iceSpiral.cooldownTime);
        iceSpiral.cooldown = false;
    }

    private void LightningSigil()
    {
        float angleStep = 360f / lightningSigil.projectileCount;
        float angle = 0f;
        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
        float randomAngle = Random.Range(0, 180);

        for (int i = 0; i < lightningSigil.projectileCount; i++)
        {
            float dirX = pos.x + Mathf.Sin(angle * Mathf.PI / 180);
            float dirY = pos.y + Mathf.Cos(angle * Mathf.PI / 180);

            Vector2 lightningV = new Vector2(dirX, dirY);
            Vector2 lightningDir = (lightningV - pos).normalized;

            float textureAngle = Mathf.Atan2(lightningDir.y, lightningDir.x) * Mathf.Rad2Deg - randomAngle;
            GameObject newLightning = Instantiate(lightningGO, transform.position, Quaternion.Euler(0, 0, textureAngle + 180f));

            Destroy(newLightning, lightningSigil.duration);

            angle += angleStep;
        }
    }

    private IEnumerator LightningSigilCooldown()
    {
        lightningSigil.cooldown = true;
        yield return new WaitForSeconds(lightningSigil.cooldownTime);
        lightningSigil.cooldown = false;
    }

    private IEnumerator Dash()
    {
        Player player = GetComponent<Player>();
        player.immune = true;
        Vector2 moveDir = GetComponent<PlayerMovement>().movement.normalized;
        Vector2 startPoint = transform.position;
        Vector2 endPoint = startPoint + moveDir * dash.distance;

        float totalMovementTime = 0.15f;
        float currentMovementTime = 0f;
        float singleMovementTime = totalMovementTime / 10;
        while (currentMovementTime < totalMovementTime)
        {
            currentMovementTime += singleMovementTime;
            RaycastHit2D colliderCheck = Physics2D.Raycast(startPoint, moveDir, dash.distance);
            if (colliderCheck.collider == null ||
                colliderCheck.collider.CompareTag("pelaaja") ||
                colliderCheck.collider.CompareTag("enemy") ||
                colliderCheck.collider.CompareTag("super-enemy") ||
                colliderCheck.collider.CompareTag("object") ||
                colliderCheck.collider.CompareTag("water") ||
                colliderCheck.collider.CompareTag("waterFull") ||
                colliderCheck.collider.CompareTag("damageP") ||
                colliderCheck.collider.CompareTag("damage1") ||
                colliderCheck.collider.CompareTag("Coin") ||
                colliderCheck.collider.CompareTag("Health") ||
                colliderCheck.collider.CompareTag("StoryNote") ||
                colliderCheck.collider.CompareTag("StoryNote1") ||
                colliderCheck.collider.CompareTag("StoryNote2") ||
                colliderCheck.collider.CompareTag("StoryNote3") ||
                colliderCheck.collider.CompareTag("StoryNote4"))
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
        dash.cooldown = true;
        yield return new WaitForSeconds(dash.cooldownTime);
        dash.cooldown = false;
    }
}