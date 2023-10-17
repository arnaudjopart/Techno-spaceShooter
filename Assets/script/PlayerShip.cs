using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerShip : InputListenerBase
{
    private Rigidbody2D m_rigidBody;
    [SerializeField] private float m_impulse;
    [SerializeField] private float m_rotationSpeed;
    private WeaponSystemBase m_weaponSystem;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_weaponSystem = GetComponent<WeaponSystemBase>();
    }
    public override void ProcessInputAxes(Vector2 input)
    {
        m_rigidBody.AddForce(transform.up * m_impulse*input.y);
        transform.rotation *= Quaternion.Euler(0, 0, -input.x*m_rotationSpeed*Time.deltaTime);
    }

    public void ProcessMousePosition(Vector3 mousePosition)
    {
        
    }

    public override void ProcessKeyCodeDown(KeyCode space)
    {
        
    }

    public override void ProcessKeyCodeUp(KeyCode space)
    {
        
    }

    public override void ProcessMouseButtonDown(int _button)
    {
        if (_button == 0) { 
            m_weaponSystem.ProcessShootPrimaryWeapon();
            
        }
        if (_button == 1 ) 
        {
            m_weaponSystem.ProcessShootSecondaryWeapon();

        }
    }
}