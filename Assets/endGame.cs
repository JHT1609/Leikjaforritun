using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour
{
    private bool EndofGame;
    public GameObject EndGameObject;
    //Þetta fer bara á eina hurð sem er notuð til að enda leikin og segja að þú ert búin að vinna leikinn
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            EndGameObject.SetActive(true);
            EndofGame = true;
        }
    }
}
