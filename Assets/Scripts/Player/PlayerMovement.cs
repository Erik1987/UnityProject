using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public Vector2 movement;
    private Scene previousScene;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private int currentScene = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject[] enemies = FindObjectsOfType<GameObject>().Where(s => s.scene == SceneManager.GetActiveScene()).Where(s => s.name.Contains("Enemy") && !s.name.Contains("Spawn")).ToArray();

        if (collision.collider.CompareTag("NextScene"))
        {
            if (SceneManager.GetActiveScene().name != "First Room")
            {
                if (!enemies.Any())
                {
                    previousScene = SceneManager.GetActiveScene();
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene " + (currentScene + 1)));
                    currentScene++;
                }
            }
            else
            {
                previousScene = SceneManager.GetActiveScene();
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene " + (currentScene + 1)));
                currentScene++;
            }
        }
        if (collision.collider.CompareTag("PreviousScene"))
        {
            if (SceneManager.GetActiveScene().name != "Scene 1")
            {
                if (!enemies.Any())
                {
                    previousScene = SceneManager.GetActiveScene();
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene " + (currentScene - 1)));
                    currentScene--;
                }
            }
        }

        if (collision.collider.CompareTag("DoorToStore"))
        {
            if (!enemies.Any())
            {
                previousScene = SceneManager.GetActiveScene();
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Store"));
            }
        }

        if (collision.collider.CompareTag("DoorToBoss"))
        {
            if (!enemies.Any())
            {
                previousScene = SceneManager.GetActiveScene();
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("bossHuone"));
            }
        }

        if (collision.collider.CompareTag("BackFromBoss"))
        {
            previousScene = SceneManager.GetActiveScene();
            SceneManager.SetActiveScene(previousScene);
        }

        if (collision.collider.CompareTag("BackFromStore"))
        {
            previousScene = SceneManager.GetActiveScene();
            SceneManager.SetActiveScene(previousScene);
        }
    }
}