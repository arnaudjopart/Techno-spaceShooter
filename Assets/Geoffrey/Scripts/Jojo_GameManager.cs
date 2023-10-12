using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jojo_GameManager : MonoBehaviour
{
    public static Jojo_GameManager instance { private set; get; }
    private static int m_int;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }
    public static void ChangeSceneStatic(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }


    public void Quit()
    {
        Application.Quit();
    }
}
