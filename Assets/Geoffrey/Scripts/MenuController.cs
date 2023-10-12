using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PanelType
{
    None,

    Main,

    Settings,

}
public class MenuController : MonoBehaviour
{
    private Jojo_GameManager manager;

    private void Start()
    {
        manager = Jojo_GameManager.instance;
    }
    public void ChangeScene(string _sceneName)
    {
        manager.ChangeScene(_sceneName);
    }

    public void OpenPanel()
    {

    }
    public void Quit()
    {
        manager.Quit();
    }
}
