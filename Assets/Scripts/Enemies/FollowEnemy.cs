using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public GameObject TrackObject;
    public Vector3 Offset;

    // Update is called once per frame
    private void Update()
    {
        gameObject.transform.position = Camera.main.WorldToScreenPoint(TrackObject.transform.position) + Offset;
    }
}