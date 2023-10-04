using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public InputListenerBase m_inputListener;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var mousePosition = Input.mousePosition;
        
        m_inputListener.ProcessMousePosition(mousePosition);
        m_inputListener.ProcessInputAxes(input);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_inputListener.ProcessKeyCodeDown(KeyCode.Space);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_inputListener.ProcessKeyCodeUp(KeyCode.Space);
        }
    }
}
