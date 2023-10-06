using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public InputListenerBase m_playerShip;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputRaw = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        var mousePosition = Input.mousePosition;

        m_playerShip.ProcessMousePosition(mousePosition);
        m_playerShip.ProcessInputAxes(input);
        m_playerShip.ProcessInputAxesRaw(inputRaw);

        if (Input.GetMouseButtonDown(0)) m_playerShip.ProcessMouseButtonDown(0);
        if (Input.GetMouseButtonDown(1)) m_playerShip.ProcessMouseButtonDown(1);
        if (Input.GetMouseButtonUp(0)) m_playerShip.ProcessMouseButtonUp(0);
        if (Input.GetMouseButtonUp(1)) m_playerShip.ProcessMouseButtonUp(1);
        

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
