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
    [SerializeField] SelectionMenu m_selectionMenu;
    [SerializeField] GameObject m_mainMenu;
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

    public void ShowSelectionMenu()
    {
        m_selectionMenu.gameObject.SetActive(true);
        m_mainMenu.SetActive(false);


    }
    public void ReturnToMainMenu()
    {
        m_selectionMenu.gameObject.SetActive(false);
        m_mainMenu.SetActive(true);


    }
}
