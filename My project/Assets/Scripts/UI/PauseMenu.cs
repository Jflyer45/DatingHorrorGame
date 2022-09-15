using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool phoneUIActive = false;
    public GameObject pauseMenuUI;
    public GameObject phoneUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Pusing p");
            if (phoneUIActive)
            {
                PhoneUIOff();
            }
            else
            {
                PhoneUIOn();
            }
        }
    }

    public void Resume()
    {
        DisableCursor();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        EnableCursor();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    private void PhoneUIOn()
    {
        phoneUI.SetActive(true);
        EnableCursor();
        phoneUIActive = true;
    }

    private void PhoneUIOff()
    {
        phoneUI.SetActive(false);
        DisableCursor();
        phoneUIActive = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneLoaderUtils.Scene.MainMenu);
        Debug.Log("Pressed Menu Button");
    }

    public void QuitGame()
    {
        Debug.Log("Pressed Quit Button");
        Application.Quit();
    }

    // Private Methods
    private void EnableCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void DisableCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
