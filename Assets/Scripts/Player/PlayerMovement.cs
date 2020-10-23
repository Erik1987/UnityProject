using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public Vector2 movement;

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
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene " + (currentScene + 1)));
                    currentScene++;
                }
            }
            else
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene " + (currentScene + 1)));
                currentScene++;
            }
        }
        //GameObject[] spawns = FindObjectsOfType<GameObject>().Where(s => s.scene == SceneManager.GetActiveScene()).Where(s => s.name.ToLower().Contains("spawn")).ToArray();

        //if (collision.collider.CompareTag("enemy"))
        //{
        //    var randomSpawn = Random.Range(0, spawns.Count());
        //    transform.position = new Vector3(spawns[randomSpawn].transform.position.x + 1f, spawns[randomSpawn].transform.position.y - 1f, 0f);
        //}

        if (collision.collider.CompareTag("PreviousScene"))
        {
            if (SceneManager.GetActiveScene().name != "Scene 1")
            {
                if (!enemies.Any())
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene " + (currentScene - 1)));
                    currentScene--;
                }
            }
        }
    }
}