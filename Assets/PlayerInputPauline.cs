using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputPauline : InputListenerBase
{
    public override void ProcessInputAxes(Vector2 _inputAxes)
    {
        //Vector3 movement = _inputAxes;
        //transform.position += movement*Time.deltaTime;
        Vector3 direction = new Vector3(_inputAxes.x, _inputAxes.y, 0f);
        //float angle = Mathf.Atan2(-_inputAxes.x, _inputAxes.y);
        //angle = Mathf.Rad2Deg * angle;
        //Debug.Log(angle);
        //Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.up = direction;





    }
}
