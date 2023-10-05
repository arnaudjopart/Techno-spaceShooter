using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : InputListenerBase
{
    [SerializeField] GameObject projectile;
    [SerializeField] int speed;
    public override void ProcessMousePosition(Vector2 _mousePosition)
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward,Camera.main.ScreenToWorldPoint(_mousePosition));
    }

    public override void ProcessInputAxes(Vector2 _inputAxes)
    {
        transform.position += new Vector3(_inputAxes.x, _inputAxes.y, 0)* Time.deltaTime * speed;
    }
    public override void ProcessMouseButtonDown(int _button)
    {
        
        Debug.Log("ca marche");
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
