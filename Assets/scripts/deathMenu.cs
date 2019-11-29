using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathMenu : MonoBehaviour
{
    //Hérna eru valkostir sem spilarinn fær þegar hann deyr
    public void RestartGame()
    {
        //load-a level 1 þar sem maður velur diffeculty
        SceneManager.LoadScene(1);
    }

    public void QuitToTitelScreen()
    {
        //til að fara aftur á heima skjáinn
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
