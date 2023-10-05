
using UnityEngine;

public class PlayerShipPauline : InputListenerBase
{
    [SerializeField] int speed;
    private int rotation_Z;

    public override void ProcessInputAxesRaw(Vector2 _inputAxes)
    {
        if (_inputAxes.magnitude == 0) return;
        var direction = new Vector3(_inputAxes.x, _inputAxes.y, 0).normalized;
        transform.position += direction  * speed * Time.deltaTime;
        transform.up = direction;
        /*transform.rotation = Quaternion.Euler(0, 0, rotation_Z);
        if (_inputAxes.x < 0)  rotation_Z = 90;
        if (_inputAxes.x > 0) rotation_Z = -90;
        if (_inputAxes.y > 0) rotation_Z = 0;
        if (_inputAxes.y < 0) rotation_Z = 180;
        if (_inputAxes.x < 0 && _inputAxes.y > 0) rotation_Z = 45;
        if (_inputAxes.x < 0 && _inputAxes.y < 0) rotation_Z = 135;
        if (_inputAxes.x > 0 && _inputAxes.y < 0) rotation_Z = 225;
        if (_inputAxes.x > 0 && _inputAxes.y > 0) rotation_Z = 315;*/


    }
}

  
