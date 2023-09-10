using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject otherTarget;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (CoinController.gameState != "playing")
        {
            transform.position = new Vector3(0, 0, -10);
        }

        if (player != null)
        {
            if (player.transform.position.y > transform.position.y)
            {
                //プレイヤーの位置と連動させる
                transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            }else
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y, -10);
            }
        }
    }
}
