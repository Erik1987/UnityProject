using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBubble : MonoBehaviour
{
    public float time = 4; 

    void Start()
    {
        Destroy(gameObject, time);
    }
}
