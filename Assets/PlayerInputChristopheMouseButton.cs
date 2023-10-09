using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputChristopheMouseButton : InputListenerBase
{
    [SerializeField]
    float forwardSpeed;
    Vector3 clickPosition;
    bool isClicked = false;

    private void Update()
    {
        //float thrust = transform.position.y + forwardSpeed*Time.deltaTime;
        //Vector2 forwardThrust = new Vector2 (transform.position.x, thrust);
        //transform.position = forwardThrust;
        if (isClicked)
        {
        transform.Translate(Vector3.up*forwardSpeed*Time.deltaTime);

        }
    }

    public override void ProcessMousePosition(Vector2 _mousePosition)
    {
       clickPosition = _mousePosition;
    }

    public override void ProcessMouseButtonDown(int _button)
    {
        isClicked = true;
        Vector3 direction = Camera.main.ScreenToWorldPoint(clickPosition);
        direction.z = 0;
        direction -= transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    

}
