using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerInputChristophe2 : InputListenerBase
{
    public override void ProcessInputAxes(Vector2 _inputAxes)
    {
        transform.position += new Vector3(_inputAxes.x, _inputAxes.y, 0)*Time.deltaTime;

    }

}
