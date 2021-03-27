using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuMusic : MonoBehaviour
{
     AudioSource audioData;

   
    // Start is called before the first frame update

    public void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.enabled = true;
        Debug.Log("Müzik Başladı");
    }

    public void Music()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioData.playOnAwake = true;
        }
    }

    
}
