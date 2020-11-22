using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    private void playFootstep() 
    { 
        animationPlayer.volume = Random.Range(0.2f, 0.3f);
        animationPlayer.pitch = Random.Range(1f, 1.17f);
        animationPlayer.Play();
    }
}