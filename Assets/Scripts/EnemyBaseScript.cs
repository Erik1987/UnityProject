using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBaseScript : Agent
{
    public Rigidbody2D rBody;
    public GameObject target;

    private void Start()
    {
    }

    public override void OnEpisodeBegin()
    {
        string spawnerName = $"EnemySpawn{Regex.Replace(transform.gameObject.name, "[^0-9.]", "")}(Clone)";
        if (SceneManager.GetActiveScene().name != "First Room" && SceneManager.GetActiveScene().name != "pohjascene")
        {
            transform.position = SceneManager.GetActiveScene().GetRootGameObjects().FirstOrDefault().transform.Find(spawnerName).position;
        }
    }

    private Vector2 movement = Vector2.zero;

    private List<GameObject> _enemyCache;

    public override void CollectObservations(VectorSensor sensor)
    {
        if (_enemyCache == null)
        {
            _enemyCache = new List<GameObject>();
            _enemyCache.AddRange(FindObjectsOfType<GameObject>().Where(s => s.scene == SceneManager.GetActiveScene()).Where(s => s.name.Contains("Enemy")).ToList());
        }

        float distanceToTarget = Vector2.Distance(this.transform.position, target.transform.position);
        if (distanceToTarget > 1.4f)
        {
            sensor.AddObservation(false);
        }
        if (distanceToTarget < 1.4f)
        {
            sensor.AddObservation(true);
        }
        // Target and Agent positions
        sensor.AddObservation(target.transform.position);
        sensor.AddObservation(this.transform.position);

        foreach (var target in _enemyCache)
        {
            sensor.AddObservation(target.transform.localPosition);
            sensor.AddObservation(this.transform.localPosition);
        }
    }

    public float forceMultiplier = 5;

    public override void OnActionReceived(float[] vectorAction)
    {
        SetReward(-0.005f);

        // Actions, size = 2
        movement.x = vectorAction[0];
        movement.y = vectorAction[1];
        rBody.MovePosition(movement * forceMultiplier);

        // Rewards
        float distanceToTarget = Vector2.Distance(this.transform.position, target.transform.position);
        // Reached target
        if (distanceToTarget < 1.4f)
        {
            SetReward(10.0f);
            EndEpisode();
        }
    }

    private void FixedUpdate()
    {
        rBody.MovePosition(rBody.position + movement * forceMultiplier * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("seinä"))
        {
            SetReward(-1.0f);
            EndEpisode();
        }

        if (collision.collider.CompareTag("enemy"))
        {
            SetReward(-1.0f);
            EndEpisode();
        }

        if (collision.collider.CompareTag("pelaaja"))
        {
            Destroy(transform.gameObject);
        }
    }
}