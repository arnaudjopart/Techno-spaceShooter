using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerShip : InputListenerBase
{
    private Rigidbody2D m_rigidBody;
    [SerializeField] private float m_impulse;
    [SerializeField] private float m_rotationSpeed;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }
    public override void ProcessInputAxes(Vector2 input)
    {
        m_rigidBody.AddForce(transform.up * m_impulse*input.y);
        transform.rotation *= Quaternion.Euler(0, 0, input.x*m_rotationSpeed*Time.deltaTime);
    }

    public void ProcessMousePosition(Vector3 mousePosition)
    {
        
    }

    public void ProcessKeyCodeDown(KeyCode space)
    {
        
    }

    public void ProcessKeyCodeUp(KeyCode space)
    {
        
    }
}