using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class UIGameHandler : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!this.pauseMenu.activeInHierarchy)
            {
                this.pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                this.pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MikaMainMenu_Scene");
    }
}
