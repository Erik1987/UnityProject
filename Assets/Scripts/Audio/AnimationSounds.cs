using UnityEngine;

public class AnimationSounds : MonoBehaviour
{
    private AudioSource animationPlayer;

    private void Start()
    {
        animationPlayer = GetComponent<AudioSource>();
    }

    private void Update()
    {
    }

    private void playFootstep() => animationPlayer.Play();
}