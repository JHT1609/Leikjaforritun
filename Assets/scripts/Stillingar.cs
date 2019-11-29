
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//refrens
// https://www.youtube.com/watch?v=34vXT1CrW_s

public class Stillingar : MonoBehaviour
{
    public AudioMixer audioMixer;

    [Space(10)]

    GameObject audioObject;
    AudioSource audioSource;

    /*Hérna er allt um það að læka eða hæka hljóðið og save-a það*/
    private void Update()
    {
        audioObject = GameObject.Find("AudioInstantiatior");
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
        
    }

    private void Start()
    {
        SetMusicVolume(PlayerPrefs.GetFloat("musicVolume", 0));
    }

    private void OnDisable()
    {
        float musicVolume = 0;

        audioMixer.GetFloat("musicVolume", out musicVolume);

        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.Save();
    }
    //----------------------------------------------------
    
    // Þetta er til að setja þig aftur inn í levelið sem maður var í
    public void BackToGame()
    {
        GameManager GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        SceneManager.LoadScene(GM.lastLevel);
    }
}
