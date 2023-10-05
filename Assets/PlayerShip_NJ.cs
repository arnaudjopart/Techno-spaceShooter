using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip_NJ : InputListenerBase
{
    public float moveSpeed = 5f;
    private Rigidbody2D _rb;
    private Vector2 _mousePositionAtFrame;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogError("Rigidbody2D not found on the GameObject.");
        }
    }
    public override void ProcessMouseButtonDown(int _button)
    {
Debug.Log("ProcessMouseButtonDown");
        Vector2 rayOrigin = Camera.main.ScreenToWorldPoint(_mousePositionAtFrame);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero);

        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
Debug.Log("Hit " + hitObject.name);
            Destroy(hitObject);
        }
    }
    public override void ProcessMouseButtonUp(int _button)
    {
        Debug.Log("ProcessMouseButtonUp");
    }
    public override void ProcessMousePosition(Vector2 _mousePosition)
    {
        _mousePositionAtFrame = _mousePosition;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(_mousePosition.x, _mousePosition.y, Camera.main.nearClipPlane));
        Vector2 lookDirection = (mouseWorldPosition - transform.position).normalized;

        float angleOffset = 0f; // Adjust this offset as needed
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + angleOffset;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    public override void ProcessInputAxes(Vector2 _inputAxes)
    {
        _rb.velocity = new Vector2(_inputAxes.x * moveSpeed, _inputAxes.y * moveSpeed);
    }

    public override void ProcessKeyCodeDown(KeyCode _keyCode)
    {
        Debug.Log("space down");
    }

    public override void ProcessKeyCodeUp(KeyCode _keyCode)
    {
        Debug.Log("space up");
    }

}
