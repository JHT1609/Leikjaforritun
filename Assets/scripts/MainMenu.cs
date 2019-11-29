using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Hér er verið að skoða hvað spilarin vil gera hvort hann vil byrja leikin fara í settings eða bara slökva á leiknum
    public void PlayGame ()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings ()
    {
        SceneManager.LoadScene(5);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
