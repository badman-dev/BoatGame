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
        if (Input.GetKeyDown(KeyCode.Escape))
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

        //player.enabled = false;
        //camera.enabled = false;
    }

    public void CloseScreens()
    {
        foreach (GameObject panel in pausePanels)
        {
            panel.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.Locked;
        paused = false;

        //player.enabled = true;
        //camera.enabled = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
