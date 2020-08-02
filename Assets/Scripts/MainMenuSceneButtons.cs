using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneButtons : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }

    public void BackToMainMenu()
    {
       SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
