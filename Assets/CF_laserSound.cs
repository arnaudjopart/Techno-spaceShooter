using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_laserSound : MonoBehaviour
{
    AudioSource m_AudioSource;
    [SerializeField]
    AudioClip m_laser;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource.PlayOneShot(m_laser);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
