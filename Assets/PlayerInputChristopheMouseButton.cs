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

        //Vector3 direction = new Vector3(clickPosition.x, clickPosition.y, 0)/*-transform.position*/;
        //clickPosition.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
        //clickPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        //transform.LookAt(clickPosition);

        //float angle = Mathf.Atan2(Camera.main.ScreenToWorldPoint(direction).y, Camera.main.ScreenToWorldPoint(direction).x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction/*Camera.main.ScreenToWorldPoint(direction)-transform.rotation.eulerAngles*/);
    }
}
