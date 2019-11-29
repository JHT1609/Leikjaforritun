using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lastLevel = 0;

    // Start is called before the first frame update
    void Awake()
    {
        SceneManager.sceneLoaded += CustomStart;
        DontDestroyOnLoad(this.gameObject);
    }
    // Hér er verið að skoða í hvað level maður var í
    void CustomStart(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene")
        {
            lastLevel = 1;
        }
        else if (scene.name == "level1")
        {
            lastLevel = 2;
        }
        else if (scene.name == "level2")
        {
            lastLevel = 3;
        }
        else if (scene.name == "level3")
        {
            lastLevel = 4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
