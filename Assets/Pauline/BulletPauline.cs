using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPauline : MonoBehaviour
{
    [SerializeField] float bulletLifetime = 1f;
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(gameObject, bulletLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
