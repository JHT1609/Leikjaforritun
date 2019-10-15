
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


//refrens
// https://www.youtube.com/watch?v=34vXT1CrW_s

public class Stillingar : MonoBehaviour
{
    public AudioMixer audioMixer;

    [Space(10)]
    public Slider musicSlider;
    public Slider sfxSlider;

    GameObject audioObject;
    AudioSource audioSource;
    Slider slider;


    private void Start()
    {
        audioObject = GameObject.Find("AudioInstantiatior");
        audioSource = audioObject.GetComponent<AudioSource>();
        slider = GetComponent<Slider>();

        musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 0);
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 0);

    }
    //----------------- volume en virkar ekki er ekki dynamic --------------------------
    public void UpdateAudio()
    {
        audioSource.volume = slider.value;
    }


    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
        
    }

    public void SetfxVolume(float volume)
    {
        audioMixer.SetFloat("sfxVolume", volume);
        if(audioMixer.SetFloat("sfxVolum", -80))
        {

        }
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        float musicVolume = 0;
        float sfxVolume = 0;

        audioMixer.GetFloat("musicVolume", out musicVolume);
        audioMixer.GetFloat("sfxVolume", out sfxVolume);

        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
        PlayerPrefs.Save();
    }
    //----------------------------------------------------

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
