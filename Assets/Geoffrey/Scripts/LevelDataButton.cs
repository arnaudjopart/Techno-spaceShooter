using Mika;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class LevelDataButton : MonoBehaviour
{
    private LevelData m_levelData;
    private SelectionMenu m_manager;

    [SerializeField] private TMP_Text m_text;

    internal void Init(LevelData levelData, SelectionMenu _manager)
    {
        m_levelData = levelData;
        m_manager = _manager;
        m_text.SetText(m_levelData.name);
    }

    public void OnButtonClic()
    {
        m_manager.ValidateButtonClick(m_levelData.sceneName);
    }
}