using System.Linq;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBaseScript : Agent
{
    private Rigidbody2D rBody;

    private void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        rBody.gravityScale = 0;
    }

    public override void OnEpisodeBegin()
    {
        if (SceneManager.GetActiveScene().name != "First Room")
        {
            transform.position = transform.parent.position;
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        GameObject[] enemies = FindObjectsOfType<GameObject>().Where(s => s.scene == SceneManager.GetActiveScene()).Where(s => s.name.Contains("Enemy")).ToArray();

        foreach (var target in enemies)
        {
            sensor.AddObservation(target.transform.localPosition);
            sensor.AddObservation(this.transform.localPosition);
        }
    }

    public float forceMultiplier = 5;

    public override void OnActionReceived(float[] vectorAction)
    {
        GameObject[] enemies = FindObjectsOfType<GameObject>().Where(s => s.scene == SceneManager.GetActiveScene()).Where(s => s.name.Contains("Enemy")).ToArray();

        SetReward(0.05f);

        // Actions, size = 2
        Vector2 movement = Vector2.zero;
        movement.x = vectorAction[0];
        movement.y = vectorAction[1];
        rBody.AddForce(movement * forceMultiplier);

        foreach (var target in enemies)
        {
            float distanceToTarget = Vector2.Distance(this.transform.localPosition, target.transform.localPosition);
            // Reached target
            if (distanceToTarget < 1.4f)
            {
                SetReward(-10.0f);
                EndEpisode();
            }
        }
    }

    private int currentScene = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject[] enemies = FindObjectsOfType<GameObject>().Where(s => s.scene == SceneManager.GetActiveScene()).Where(s => s.name.Contains("Enemy")).ToArray();

        if (collision.collider.CompareTag("NextScene"))
        {
            if (SceneManager.GetActiveScene().name != "First Room")
            {
                if (!enemies.Any())
                {
                    SetReward(10.0f);
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene " + (currentScene + 1)));
                    currentScene++;
                }
            }
            else
            {
                SetReward(10.0f);
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
                    SetReward(10.0f);
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene " + (currentScene - 1)));
                    currentScene--;
                }
            }
        }
    }
}