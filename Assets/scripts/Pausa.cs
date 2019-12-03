using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject pauseMenuCanvas;

    // þetta er allt pause menu
    private void Update()
    {
        //skoða ef það á að kveikja á pause menu eða slökva
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuCanvas.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuCanvas.SetActive(false);
        }
    }

    public void PlayGame()
    {
        // halda áfram með leikin hér
        pauseMenuCanvas.SetActive(false);
    }

    public void Settings(string levelName)
    {
        // fara í settings
        SceneManager.LoadScene(levelName);
    }

    public void LevelSelectMenu(string levelName)
    {
        // breita um level
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        // slökva á leiknum
        Application.Quit();
    }
}
