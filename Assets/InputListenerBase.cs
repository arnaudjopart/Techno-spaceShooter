using System;
using UnityEngine;

public class InputListenerBase : MonoBehaviour
{
    public virtual void ProcessMouseButtonDown(int _button)
    {

    }
    public virtual void ProcessMouseButtonUp(int _button)
    {

    }
    public virtual void ProcessMousePosition(Vector2 _mousePosition)
    {

    }
    public virtual void ProcessInputAxes(Vector2 _inputAxes)
    {

    }
    public virtual void ProcessKeyCodeDown(KeyCode _keyCode)
    {

    }
    public virtual void ProcessKeyCodeUp(KeyCode _keyCode)
    {

    }

    public virtual void ProcessInputAxesRaw(Vector2 _inputRaw)
    {
        
    }
}
