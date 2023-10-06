using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerInputChristophe : InputListenerBase
{
    [SerializeField]
    float moveSpeed = 50;
    float rotationSpeed = 0.05f;
    
    public override void ProcessMousePosition(Vector2 _mousePosition)
    {

        transform.rotation = Quaternion.LookRotation(Vector3.forward, Camera.main.ScreenToWorldPoint(_mousePosition));
        transform.position = Vector3.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(_mousePosition), Time.deltaTime*moveSpeed);
    }

}
