using UnityEngine;
using UnityEngine.UI;

public class MusicToggleUI : MonoBehaviour
{
    public Toggle musicToggle;

    void Start()
    {
        bool musicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
        musicToggle.isOn = musicOn;

        musicToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isOn)
    {
        if (MusicPlayer.instance != null)
        {
            MusicPlayer.instance.ToggleMusic(isOn);
        }

        else
        {
            // Save preference even if music isn't currently playing
            PlayerPrefs.SetInt("MusicOn", isOn ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}
