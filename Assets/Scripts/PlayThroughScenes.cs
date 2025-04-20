using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public string[] allowedScenes; // List of scene names to play music in
    private AudioSource audioSource;
    public static MusicPlayer instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();

            // Load and apply saved preference
            bool musicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
            audioSource.mute = !musicOn;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        bool allowed = false;

        foreach (string allowedScene in allowedScenes)
        {
            if (scene.name == allowedScene)
            {
                allowed = true;
                break;
            }
        }

        if (!allowed)
        {
            Destroy(gameObject);
        }
    }

    public void ToggleMusic(bool isOn)
    {
        if (audioSource != null)
        {
            audioSource.mute = !isOn;
            PlayerPrefs.SetInt("MusicOn", isOn ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
