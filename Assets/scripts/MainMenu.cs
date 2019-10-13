using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

<<<<<<< HEAD:Assets/scripts/MainMenu.cs
    public void Settings ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

=======
>>>>>>> 2ceeffda8831147ae0f254386acaed9f0db52e4a:Assets/MainMenu.cs
    public void QuitGame ()
    {
        Application.Quit();
    }
}
