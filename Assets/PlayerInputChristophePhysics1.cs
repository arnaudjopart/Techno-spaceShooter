using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerInputChristophePhysics1 : InputListenerBase
{
    Rigidbody2D rb;
    [SerializeField] float rotationSpeed;
    [SerializeField] float forwardSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void ProcessInputAxes(Vector2 _inputAxes)
    {
      rb.AddRelativeForce(new Vector2(0,_inputAxes.y) * forwardSpeed);
      rb.rotation += _inputAxes.x*Time.deltaTime*rotationSpeed;
    }

}
