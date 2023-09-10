using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    Rigidbody2D rbody;
    
    public float jump = 9.0f;
    
    bool goJump = false;
    bool onGround = false;
    
    public static string gameState = "gameover";
    
    int ForceValue;
    int WeightValue;
        
    Vector2 startPos;

    public LayerMask wallLayer;   // 着地できるレイヤー

    GameObject gateObj;

    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();

        ForceValue = Setting.ForceValue;
        WeightValue = Setting.WeightValue;
        rbody.mass = WeightValue + 1;
        Debug.Log("Coin ForceValue: " + ForceValue + ", WeightValue: " + WeightValue);
    }

    void Update()
    {
        float jumpTemp;
        if (gameState != "playing")
        {
            return;
        }
        if (Input.GetKey(KeyCode.A))
        {
            jumpTemp = 50.0f;
            Jump(jumpTemp);
        }
        if (Input.GetKey(KeyCode.S))
        {
            jumpTemp = 35.0f;
            Jump(jumpTemp);
        }
        if (Input.GetKey(KeyCode.D))
        {
            jumpTemp = 10.0f;
            Jump(jumpTemp);
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    this.startPos = Input.mousePosition;
        //}
        //if (Input.GetMouseButtonUp(0))
        //{
        //    Vector2 endPos = Input.mousePosition;
        //    float swipeLength = Vector2.Distance(endPos, this.startPos);
        //    //float swipeLength = (endPos.x - this.startPos.x);
        //    //this.jump = swipeLength / 500.0f;
        //    jumpTemp = swipeLength / (ForceValue+1) * 0.1f;
        //    Debug.Log("Coin swipeLength: " + swipeLength + ", jumpTemp: " + jumpTemp);
        //    if (jumpTemp >= 50.0f)
        //    {
        //        jumpTemp = 50.0f;
        //    }
        //    Jump(jumpTemp);
        //}
    }

    void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }
        //if (transform.position.x > 0)
        //{
        //    onGround = Physics2D.Linecast(transform.position, transform.position + (transform.right * 0.1f), wallLayer);
        //}
        //else
        //{
        //    onGround = Physics2D.Linecast(transform.position, transform.position - (transform.right * 0.1f), wallLayer);
        //}
        if (transform.position.x > 0)
        {
            onGround = Physics2D.Linecast(transform.position, transform.position + (Vector3.right * 0.5f), wallLayer);
            //Debug.Log("transform.position.x > 0; " + onGround + " , " + transform.position + " , " + Vector3.right);
        }
        else
        {
            onGround = Physics2D.Linecast(transform.position, transform.position + (Vector3.left * 0.5f), wallLayer);
            //Debug.Log("transform.position.x < 0; " + onGround + " , " + transform.position + " , " + Vector3.left);
        }
        //goJump = false;
        //onGround = true;
        if (onGround && goJump)
        {
            Vector2 jumpPw;
            if (transform.position.x > 0)
            {
                jumpPw = new Vector2(-jump, 0);
            }
            else
            {
                jumpPw = new Vector2(jump, 0);
            }
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);
            goJump = false;
        }
    }

    public void Jump(float jp)
    {
        jump = jp;
        goJump = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            //Debug.Log("Goal");
            Goal();
        }
        else if (collision.gameObject.tag == "Hole")
        {
            //Debug.Log("GameOver");
            GameOver();
        }
        else if (collision.gameObject.tag == "ScoreItem")
        {
            //// スコアアイテム
            //// ItemData を得る
            //ItemData item = collision.gameObject.GetComponent<ItemData>();
            //// スコアを得る
            //score = item.value;
            //// アイテム削除する
            //Destroy(collision.gameObject);
        }
    }
    // ゴール
    public void Goal()
    {
        gameState = "gameclear";
        GameStop();
    }
    // ゲームオーバー
    public　void GameOver()
    {
        gameState = "gameover";
        Destroy(gameObject, 0.5f);
        GameStop();    
    }

    void GameStop()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = new Vector2(0, 0);
    }
}
