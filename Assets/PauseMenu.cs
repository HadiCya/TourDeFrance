using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject pausePanel;
    public static bool isPaused = false;

    public void Unpause()
    {
        Debug.Log("Unpausing");
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Debug.Log("Pausing");
        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
