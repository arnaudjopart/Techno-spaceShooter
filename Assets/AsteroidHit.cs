using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHit : MonoBehaviour
{
    [SerializeField] GameObject debrisPrefab;
    [SerializeField] Rigidbody rb;
    [SerializeField] float explosionForceMax;
    float explosionForce;
    [SerializeField] float angleForceMin;
    [SerializeField] float angleForceMax;
    float angleForce;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        explosionForce = Random.Range(0, explosionForceMax);
        angleForce = Random.Range(angleForceMin, angleForceMax);
    }

    public void Explode()
    {
        Destroy(gameObject);
    }

    public void SpawnDebris()
    {
        for (int i = 0; i<2;  i++)
        {
            Vector3 direction = rb.velocity;
            GameObject debris = Instantiate(debrisPrefab, transform.position, transform.rotation);
            angleForce = Random.Range(angleForceMin, angleForceMax);
            Vector3 newDirection = Quaternion.Euler(0,0,angleForce) *direction ;
            debris.GetComponent<Rigidbody>().AddForce(direction* explosionForce);
        }
    }

 
}
