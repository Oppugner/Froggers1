using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapScript : MonoBehaviour
{

    GameObject player;
    Transform playerTrans;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerTrans = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = playerTrans.position;
        position.y = transform.position.y;
        transform.position = position;
    }
}
