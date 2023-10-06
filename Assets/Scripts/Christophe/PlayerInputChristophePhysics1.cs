using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerInputChristophePhysics1 : InputListenerBase
{
    Rigidbody2D rb;
    [SerializeField] float rotationSpeed;
    [SerializeField] float forwardSpeed;
    [SerializeField] GameObject laser;
    [SerializeField] GameObject bomb;
    [SerializeField] Vector3 laseroffset;
    [SerializeField] Vector3 bomboffset;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void ProcessInputAxes(Vector2 _inputAxes)
    {
      rb.AddRelativeForce(new Vector2(0,_inputAxes.y) * forwardSpeed);
      rb.rotation += -_inputAxes.x*Time.deltaTime*rotationSpeed;
    }

    public override void ProcessMouseButtonDown(int _button)
    {
        if (_button == 0)
        {
            Instantiate(laser, transform.TransformPoint(laseroffset), transform.rotation);
        }
        else
        {
            Instantiate(bomb, transform.position+ bomboffset, transform.rotation);
            var test = transform.position + transform.right * .5f;

        }
    }

}
