using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Mika
{
    [DefaultExecutionOrder(1000)]
    public class UIMainMenuHandler : MonoBehaviour
    {
        [SerializeField] private GameObject layoutMain, layoutOptions;
        [SerializeField] private Slider masterSlider, musicSlider, ambientSlider, playerSlider, hostileSlider;
        [SerializeField] private Toggle toggleVolume;

        private void Start()
        {
            masterSlider.value = SoundManager.Instance.GetMasterVolume();
            musicSlider.value = SoundManager.Instance.GetMusicVolume();
            ambientSlider.value = SoundManager.Instance.GetAmbientVolume();
            playerSlider.value = SoundManager.Instance.GetPlayerVolume();
            hostileSlider.value = SoundManager.Instance.GetHostileVolume();
            toggleVolume.isOn = SoundManager.Instance.IsVolumeActive();
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
            layoutMain.SetActive(false);
            layoutOptions.SetActive(true);
        }

        public void BackToMainMenu()
        {
            layoutOptions.SetActive(false);
            layoutMain.SetActive(true);
        }
    }
}