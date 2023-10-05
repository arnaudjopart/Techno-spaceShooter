using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputChristophe1 : InputListenerBase
{
    public override void ProcessInputAxes(Vector2 _inputAxes)
    {
        transform.position += new Vector3(_inputAxes.y, 0, 0)*Time.deltaTime;
        transform.Rotate(0, 0, _inputAxes.x);
    }
    public override void ProcessMousePosition(Vector2 _mousePosition)
    {
        
    }
}
