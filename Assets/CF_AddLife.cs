using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CF_AddLife : MonoBehaviour
{

    public delegate void LiveUp();
    public static LiveUp liveup;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            liveup?.Invoke();
        }
    }
}
