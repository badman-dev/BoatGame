using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject failScreen;

    public void GameFail()
    {
        Cursor.lockState = CursorLockMode.None;
        failScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameReset()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}