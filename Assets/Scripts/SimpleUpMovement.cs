using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleUpMovement : MonoBehaviour
{
    IMovable movable;
    // Start is called before the first frame update
    void Start()
    {
        movable = GetComponent<IMovable>();   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up*movable.Speed*Time.deltaTime;
    }
}
