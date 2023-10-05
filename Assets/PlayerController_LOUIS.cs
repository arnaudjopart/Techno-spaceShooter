using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_LOUIS : InputListenerBase
{
    private Vector2 target;
    private Vector3 m_mousePos;
    private bool m_mouseLeftIsDown;
    

    void Update()
    {
        if (m_mouseLeftIsDown)
        {
            target = new Vector2(m_mousePos.x, m_mousePos.y);
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * 15);
        }
    }
    public override void ProcessMousePosition(Vector2 _mousePosition)
    {
        m_mousePos = Camera.main.ScreenToWorldPoint(_mousePosition);

        Vector3 direction = new Vector3(Camera.main.ScreenToWorldPoint(_mousePosition).x, Camera.main.ScreenToWorldPoint(_mousePosition).y, 0) - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    public override void ProcessMouseButtonDown(int _button)
    {
        base.ProcessMouseButtonDown(_button);
        if (_button==0) m_mouseLeftIsDown = true;         
    }

    public override void ProcessMouseButtonUp(int _button)
    {
        base.ProcessMouseButtonDown(_button);
        if (_button == 0)  m_mouseLeftIsDown = false;
    }
}



