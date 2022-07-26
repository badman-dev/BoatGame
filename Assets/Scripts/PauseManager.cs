using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public List<GameObject> pausePanels;

    private bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                CloseScreens();
            }
            else
            {
                OpenScreen(0);
            }
        }
    }

    public void OpenScreen(int panelNum)
    {
        CloseScreens();
        Cursor.lockState = CursorLockMode.None;
        paused = true;
        pausePanels[panelNum].SetActive(true);

        Time.timeScale = 0;
    }

    public void CloseScreens()
    {
        foreach (GameObject panel in pausePanels)
        {
            panel.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.Locked;
        paused = false;

        Time.timeScale = 1;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
