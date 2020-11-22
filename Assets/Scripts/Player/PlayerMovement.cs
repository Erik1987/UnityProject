using Assets.Scripts.Player;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public Vector2 movement;
    private Player player;

    private void Start()
    {
        player = gameObject.GetComponent<Player>();
        player.trackedScenes = gameObject.AddComponent<TrackedScenes>();
        player.trackedScenes.CacheAllRoomScenes();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject[] enemies = FindObjectsOfType<GameObject>().Where(s => s.scene == SceneManager.GetActiveScene()).Where(s => s.name.Contains("Enemy") && !s.name.Contains("Spawn")).ToArray();

        if (collision.collider.CompareTag("NextScene"))
        {
            if (SceneManager.GetActiveScene().name != "First Room")
            {
                if (!enemies.Any())
                {
                    SceneManager.SetActiveScene(player.trackedScenes.NextScene);
                }
            }
            else
            {
                SceneManager.SetActiveScene(player.trackedScenes.NextScene);
            }
        }

        if (collision.collider.CompareTag("PreviousScene"))
        {
            if (SceneManager.GetActiveScene().name != "Scene 1")
            {
                if (!enemies.Any())
                {
                    SceneManager.SetActiveScene(player.trackedScenes.PreviousScene);
                }
            }
        }

        if (collision.collider.CompareTag("DoorToStore"))
        {
            if (!enemies.Any())
            {
                player.trackedScenes.OriginalScene = SceneManager.GetActiveScene();
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Shop"));
            }
        }

        if (collision.collider.CompareTag("DoorToBoss"))
        {
            if (!enemies.Any())
            {
                player.trackedScenes.OriginalScene = SceneManager.GetActiveScene();
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("bossHuone"));
            }
        }

        if (collision.collider.CompareTag("BackFromBoss"))
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.SetActiveScene(player.trackedScenes.NextScene);
            SceneManager.UnloadSceneAsync(currentScene.buildIndex);
            SceneManager.LoadSceneAsync("bossHuone", LoadSceneMode.Additive);
        }

        if (collision.collider.CompareTag("BackFromStore"))
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.SetActiveScene(player.trackedScenes.OriginalScene);
        }
    }
}