using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            Debug.Log(name+" -  Je suis le Singleton");
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != this)
            {
                Debug.Log(name + " - Je suis PAS le Singleton");
                Destroy(gameObject);
                return;
            }
        }
        
    }
}
