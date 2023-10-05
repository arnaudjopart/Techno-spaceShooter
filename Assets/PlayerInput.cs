using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerShip m_playerShip;

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var mousePosition = Input.mousePosition;

        m_playerShip.ProcessMousePosition(mousePosition);
        m_playerShip.ProcessInputAxes(input);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_playerShip.ProcessKeyCodeDown(KeyCode.Space);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_playerShip.ProcessKeyCodeUp(KeyCode.Space);
        }
    }
}
