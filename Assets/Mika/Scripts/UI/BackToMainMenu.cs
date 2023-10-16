using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mika
{
    public class BackToMainMenu : MonoBehaviour
    {
        public void ChangeScene()
        {
            SceneManager.LoadScene("MikaMainMenu_Scene");
        }
    }
}