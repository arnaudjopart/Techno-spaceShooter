using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class UIMainMenuHandler : MonoBehaviour
{
    public void LoadInputScene()
    {
        SceneManager.LoadScene("MikaInput_Scene");
    }

    public void LoadProjectileScene()
    {
        SceneManager.LoadScene("MikaProjectileScene");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
