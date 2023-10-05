using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputChristophe3 : InputListenerBase
{

    public override void ProcessMousePosition(Vector2 _mousePosition)
    {
        //transform.rotation *= Quaternion.Euler(0, 0, Camera.main.ScreenToWorldPoint(_mousePosition).x);
        transform.LookAt(Camera.main.ScreenToWorldPoint(_mousePosition));
    }

}
