using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class UIMainMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject layoutMain, layoutOptions;
    [SerializeField] private Slider masterSlider, musicSlider, ambientSlider, playerSlider, hostileSlider;
    [SerializeField] private Toggle toggleVolume;

    private void Start()
    {
        this.masterSlider.value = SoundManager.Instance.GetMasterVolume();
        this.musicSlider.value = SoundManager.Instance.GetMusicVolume();
        this.ambientSlider.value = SoundManager.Instance.GetAmbientVolume();
        this.playerSlider.value = SoundManager.Instance.GetPlayerVolume();
        this.hostileSlider.value = SoundManager.Instance.GetHostileVolume();
        this.toggleVolume.isOn = SoundManager.Instance.IsVolumeActive();
    }

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

    public void OpenOptionsMenu()
    {
        this.layoutMain.SetActive(false);
        this.layoutOptions.SetActive(true);
    }

    public void BackToMainMenu()
    {
        this.layoutOptions.SetActive(false);
        this.layoutMain.SetActive(true);
    }
}
