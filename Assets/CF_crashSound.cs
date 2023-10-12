using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_crashSound : MonoBehaviour
{
    AudioSource audiosource;
    [SerializeField]
    AudioClip crashAsteroid;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision asteroide");
        audiosource.PlayOneShot(crashAsteroid);
    }
}
