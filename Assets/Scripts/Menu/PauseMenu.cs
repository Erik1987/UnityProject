using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject pauseMenu;
    public AudioMixer audioMixer;
    public AudioMixer musicMixer;
    public AudioMixer effectMixer;
    public static bool saved = false;
    public static bool loaded = false;
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Save()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        saved = true;
    }
    public void Load()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        loaded = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void Back2Menu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("mainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        if (volume == -60)
        {
            SetVolume(-80);
        }
    }

    public void SetMusicVolume(float mvolume)
    {
        musicMixer.SetFloat("mvolume", mvolume);
        if (mvolume == -50)
        {
            SetMusicVolume(-80);
        }
    }

    public void SetEffectVolume(float evolume)
    {
        effectMixer.SetFloat("evolume", evolume);
        if (evolume == -50)
        {
            SetEffectVolume(-80);
        }
    }
}