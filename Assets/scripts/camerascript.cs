using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour
{

    [SerializeField]
    GameObject Player;

    [SerializeField]
    float timeOffset;

    [SerializeField]
    Vector2 posOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //camera start position
        Vector3 startPos = transform.position;

        //Players current position
        Vector3 endPos = Player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);
    }
}
