using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHit : MonoBehaviour
{
    [SerializeField] GameObject debrisPrefab;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float explosionForceMin;
    [SerializeField] float explosionForceMax;
    float explosionForce;

    [SerializeField] float angleForceMax;
    float angleForce;
    [SerializeField] float horizontalOffset;
    [SerializeField] float verticalOffset;
    Vector3 offset;


    private void Start()
    {
        offset.x = Random.Range(-horizontalOffset, horizontalOffset);
        offset.y = Random.Range(-verticalOffset, verticalOffset);
        offset.z = 0;
        rb = GetComponent<Rigidbody2D>();
        explosionForce = Random.Range(explosionForceMin, explosionForceMax);
        angleForce = Random.Range(-angleForceMax, angleForceMax);
    }

    public void Explode()
    {
        Debug.Log("destroy");
        Destroy(gameObject);
    }

    public void SpawnDebris()
    {
        Vector3 direction = rb.velocity;
        Debug.Log("velocity = " + direction);
        for (int i = 0; i<2;  i++)
        {
            
            offset.x = Random.Range(-horizontalOffset, horizontalOffset);
            offset.y = Random.Range(-verticalOffset, verticalOffset);
            offset.z = 0;
            GameObject debris = Instantiate(debrisPrefab, transform.position+ offset, transform.rotation);
            angleForce = Random.Range(-angleForceMax, angleForceMax);
            Vector3 newDirection = Quaternion.Euler(0,0,angleForce) *direction ;
            Debug.Log("new direction = " + newDirection);
            debris.GetComponent<Rigidbody2D>().AddForce(newDirection* explosionForce, ForceMode2D.Impulse);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        SpawnDebris();
        Explode();
    }


}
