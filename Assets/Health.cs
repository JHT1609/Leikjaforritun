using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject player;
    public Text healthScore;
   

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("ThePlayer").GetComponent<PlayerController>().health.ToString();
    }
}
