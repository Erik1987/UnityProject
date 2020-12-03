using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationSounds : MonoBehaviour
{
    [HideInInspector]
    public AudioSource[] sounds;
    [HideInInspector]
    public AudioSource step1;
    [HideInInspector]
    public AudioSource step2;
    

    private void Start()
    {
        sounds = GetComponents<AudioSource>();
        step1 = sounds[0];
        step2 = sounds[1];
    }

    private void Update()
    {
    }

    private void playFootstep() 
    { 
        if (GetComponent<PlayerMovement>().moveSpeed == 5f){
        step1.volume = Random.Range(0.17f, 0.29f);
        step1.pitch = Random.Range(1.05f, 1.23f);
        step1.Play();
        }else {
        step2.volume = Random.Range(0.17f, 0.27f);
        step2.pitch = Random.Range(1.05f, 1.23f);
        step2.Play();
        }
    }

}