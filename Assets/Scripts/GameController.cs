using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public GameObject objPrefab; 
    GameObject gateObj;

    public GameObject inputUI;

    void Start()
    {
        Transform tr = transform.Find("gate");
        gateObj = tr.gameObject;
    }

    void Update()
    {
        if (CoinController.gameState == "playing")
        {
            //inputUI.SetActive(true);
            return;
        }
        else 
        {
            //inputUI.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Coin();
        }
    }

    public void Coin()
    {
        Vector3 pos = new Vector3(gateObj.transform.position.x, gateObj.transform.position.y, transform.position.z);
        GameObject obj = Instantiate(objPrefab, pos, Quaternion.identity);
        CoinController.gameState = "playing";
    }

    public void Jump(float jp)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        CoinController coinCnt = player.GetComponent<CoinController>();
        coinCnt.Jump(jp);
    }

}
