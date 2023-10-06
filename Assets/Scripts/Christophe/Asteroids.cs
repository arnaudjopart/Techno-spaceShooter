using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [SerializeField]
    float forwardSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float horizontalOffset;
    [SerializeField] float verticalOffset;
    Vector3 offset;
    Rigidbody2D rb;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        offset.x = Random.Range(-horizontalOffset, horizontalOffset);
        offset.y = Random.Range(-verticalOffset, verticalOffset);
        offset.z = Random.Range(-rotationSpeed, rotationSpeed);
        rb.AddForce((offset - transform.position) * forwardSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position = Vector3.MoveTowards(transform.position, offset, forwardSpeed*Time.deltaTime);
        transform.Rotate(Vector3.forward, rotationSpeed*Time.deltaTime);
    }
}
