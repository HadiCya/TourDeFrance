using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pausePanel;
    bool isPaused = false;

    void OnPause()
    {
        Debug.Log("Pausing");
        if (pausePanel == null) return;

        // flip isPaused
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
