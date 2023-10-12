using System;
using UnityEngine;
using UnityEngine.UI;

internal class SelectionMenu : MonoBehaviour
{
    [SerializeField] LevelData[] m_levelData;
    [SerializeField] GameObject m_buttonPrefab;
    [SerializeField] Transform m_container;
    [SerializeField] Jojo_GameManager m_gameManager;

    internal void ValidateButtonClick(string sceneName)
    {
        m_gameManager.ChangeScene(sceneName);
    }

    private void Awake()
    {
        foreach (var levelData in m_levelData)
        {
            var newButton = Instantiate(m_buttonPrefab, m_container);
            var script = newButton.GetComponent<LevelDataButton>();
            script.Init(levelData, this);
        }
    }
}


[Serializable]
public class LevelData
{
    public string name;
    public string description;
    public string sceneName;
    public Sprite m_icon;
}