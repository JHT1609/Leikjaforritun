using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talkingToTwig : MonoBehaviour
{
    private bool onChat = false;
    private bool chat_open = false;

    [Space(10)]
    public GameObject mrTwigUI;

    /*Hérna er scripta sem skoðar hvort maður er búin að ýtta á "q" og ef maður er búin að ýtta á "q" þá opnast chat við NPS characterinn MR.Twig*/
    void Update()
    {
        if (onChat && !chat_open && Input.GetKeyDown(KeyCode.Q))
        {
            mrTwigUI.SetActive(true);
            chat_open = true;
        }
        else if (onChat && chat_open && Input.GetKeyDown(KeyCode.Q))
        {
            mrTwigUI.SetActive(false);
            chat_open = false;
            onChat = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Player")))
        {
            onChat = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player") && chat_open)
        {
            mrTwigUI.SetActive(false);
            onChat = false;
        }
    }
}
