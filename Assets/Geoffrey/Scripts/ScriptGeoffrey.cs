using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class ScriptGeoffrey : InputListenerBase
{
    [SerializeField] float moveSpeed;
    [SerializeField] float projectileSpeed;
    [SerializeField] GameObject projectile;


    public override void ProcessMousePosition(Vector2 _mousePosition)
    {
        Vector3 direction = new Vector3(Camera.main.ScreenToWorldPoint(_mousePosition).x, Camera.main.ScreenToWorldPoint(_mousePosition).y, 0) - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }
    public override void ProcessInputAxes(Vector2 _inputAxes)
    {
        transform.position += new Vector3(_inputAxes.x, _inputAxes.y, 0) * Time.deltaTime * moveSpeed;

        // Vector3 pos = transform.position;
        // pos.y += Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        // pos.x += Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        // transform.position = pos;
    }

    public override void ProcessMouseButtonDown(int _button)
    {
        if (_button == 0)
        {
            Instantiate(projectile, transform.position, transform.rotation);
        }
 
    }

    private void Update()
    {
        transform.Translate((Vector3.up) * Time.deltaTime * projectileSpeed);

    }




}
