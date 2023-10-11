using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleUpMovement : MonoBehaviour
{
    IMovable movable;
    void Start()
    {
        movable = GetComponent<IMovable>();   
    }

    void Update()
    {
        transform.position += transform.up*movable.Speed*Time.deltaTime;
    }
}
