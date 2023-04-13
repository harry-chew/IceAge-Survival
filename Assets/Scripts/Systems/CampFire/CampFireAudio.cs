using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFireAudio : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void PlayAudi()
    {
        audioSource.Play();
        audioSource.spatialBlend = 1.0f;
    }
}
