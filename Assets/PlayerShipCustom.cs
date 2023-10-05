using UnityEngine;

public class PlayerShipCustom : InputListenerBase
{
    [SerializeField] private float m_speed;

    public override void ProcessInputAxes(Vector2 _inputAxes)
    {
        transform.position += new Vector3(_inputAxes.x, _inputAxes.y,0) *m_speed*Time.deltaTime;
    }
}
