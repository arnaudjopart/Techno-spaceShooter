using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("MikaMainMenu_Scene");
    }
}
