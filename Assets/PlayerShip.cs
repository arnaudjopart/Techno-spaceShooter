using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerShip : MonoBehaviour
{
    private Rigidbody2D m_rigidBody;
    [SerializeField] private float m_impulse;
    [SerializeField] private float m_rotationSpeed;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }
    public void ProcessInputAxes(Vector2 input)
    {
        m_rigidBody.AddForce(transform.up * m_impulse*input.y);
        transform.rotation *= Quaternion.Euler(0, 0, input.x*m_rotationSpeed*Time.deltaTime);
    }

    internal void ProcessMousePosition(Vector3 mousePosition)
    {
        throw new NotImplementedException();
    }

    internal void ProcessKeyCodeDown(KeyCode space)
    {
        throw new NotImplementedException();
    }

    internal void ProcessKeyCodeUp(KeyCode space)
    {
        throw new NotImplementedException();
    }
}