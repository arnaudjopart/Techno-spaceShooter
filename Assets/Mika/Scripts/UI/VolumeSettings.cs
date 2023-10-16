using Mika;
using UnityEngine;

[DefaultExecutionOrder(1000)]
public class VolumeSettings : MonoBehaviour
{
    public void SwitchVolume()
    {
        SoundManager.Instance.SwitchVolume();
    }

    public void SetMasterVolume(float value)
    {
        SoundManager.Instance.SetMasterVolume(value);
    }

    public void SetMusicVolume(float value)
    {
        SoundManager.Instance.SetMusicVolume(value);
    }

    public void SetAmbientVolume(float value)
    {
        SoundManager.Instance.SetAmbientVolume(value);
    }

    public void SetHostileVolume(float value)
    {
        SoundManager.Instance.SetHostileVolume(value);
    }

    public void SetPlayerVolume(float value)
    {
        SoundManager.Instance.SetPlayerVolume(value);
    }
}
