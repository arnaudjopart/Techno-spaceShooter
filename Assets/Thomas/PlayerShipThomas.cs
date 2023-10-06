using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShipThomas : InputListenerBase
{
    private Rigidbody2D m_rigidBody;
    [SerializeField] private float m_impulse;
    [SerializeField] private float m_rotationSpeed;
    [SerializeField] private float m_maxSpeed;
    [SerializeField] private float m_delayBetwennJumps;
    [SerializeField] TMP_Text m_breaksText;
    private float m_timer;
    private Vector2 input;
    private bool m_stabilizeShip;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        m_breaksText = GameObject.Find("Breaks").GetComponent<TMP_Text>();
        m_timer = m_delayBetwennJumps;
        input = Vector2.zero;
        m_stabilizeShip = false;
    }

    void Update()
    {
        if (m_timer < m_delayBetwennJumps)
            m_timer += Time.deltaTime;
        if (m_stabilizeShip)
            Stabilise();
    }

    public override void ProcessInputAxes(Vector2 input)
    {
        this.input = input;
        m_rigidBody.AddForce(transform.up * m_impulse * input.y);
        if (m_rigidBody.velocity.magnitude > m_maxSpeed)
            m_rigidBody.velocity *= m_maxSpeed / m_rigidBody.velocity.magnitude;
        TPIfOut();
        transform.rotation *= Quaternion.Euler(0, 0, -input.x * m_rotationSpeed * Time.deltaTime);
    }

    public override void ProcessMouseButtonDown(int _button)
    {
        if (_button == 0 && m_timer >= m_delayBetwennJumps)
        {
            Jump();
            m_timer = 0;
        }
    }

    public override void ProcessKeyCodeDown(KeyCode _keyCode)
    {
        if (m_stabilizeShip)
        {
            m_stabilizeShip = false;
            m_breaksText.SetText("Brakes : Off");
        }
        else
        {
            m_stabilizeShip = true;
            m_breaksText.SetText("Brakes : On");
        }
    }

    public void TPIfOut()
    {
        if (transform.position.x >= 9)
            transform.Translate(-18, 0, 0, Space.World);
        if (transform.position.x <= -9)
            transform.Translate(18, 0, 0, Space.World);
        if (transform.position.y >= 5)
            transform.Translate(0, -10, 0, Space.World);
        if (transform.position.y <= -5)
            transform.Translate(0, 10, 0, Space.World);
    }

    private void Jump()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    }

    private void Stabilise()
    {
        if (input == Vector2.zero)
        {
            if (m_rigidBody.velocity.magnitude >= 0.05)
                m_rigidBody.AddForce(m_impulse * -m_rigidBody.velocity.normalized);
            else
                m_rigidBody.velocity = Vector3.zero;
        }
    }
}
