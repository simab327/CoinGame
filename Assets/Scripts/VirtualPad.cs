using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualPad : MonoBehaviour
{
    GameObject player;              // 操作するプレイヤーの GameObject 
    Vector2 defPos;                 // タブの初期座標
    Vector2 downPos;                // タッチ位置
    public bool leftLever;

    float acc;

    public float swipeLength = 0;    // タブが動く最大距離

    int ForceValue;

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーキャラクターを取得
        //player = GameObject.FindGameObjectWithTag("Player");
        // タブの初期座標
        defPos = GetComponent<RectTransform>().localPosition;
        swipeLength = 0;
        ForceValue = Setting.ForceValue;
    }

    void Update()
    {
        //    float jumpTemp;
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        this.startPos = Input.mousePosition;
        //    }
        //    if (Input.GetMouseButtonUp(0))
        //    {
        //        Vector2 endPos = Input.mousePosition;
        //        float swipeLength = Vector2.Distance(endPos, this.startPos);
        //        //float swipeLength = (endPos.x - this.startPos.x);
        //        //this.jump = swipeLength / 500.0f;
        //        jumpTemp = swipeLength / (ForceValue + 1) * 0.1f;
        //        Debug.Log("Coin swipeLength: " + swipeLength + ", jumpTemp: " + jumpTemp);
        //        if (jumpTemp >= 50.0f)
        //        {
        //            jumpTemp = 50.0f;
        //        }
        //        Jump(jumpTemp);
        //        CoinController CoCnt = player.GetComponent<PlayerController>();
        //        //    plcnt.SetAxis(0, 0);
        //        GetComponent<RectTransform>().localPosition = defPos;
        //    }
        // ローカル座標を基準に、回転を取得
        Transform myTransform = this.transform;
        Vector3 localAngle = myTransform.localEulerAngles;
        localAngle.x = 0.0f; // ローカル座標を基準に、x軸を軸にした回転を10度に変更
        localAngle.y = 0.0f; // ローカル座標を基準に、y軸を軸にした回転を10度に変更
        //localAngle.z = swipeLength / 3.0f; // ローカル座標を基準に、z軸を軸にした回転を10度に変更
        localAngle.z = swipeLength / (ForceValue + 1) * 1.0f;
        if (leftLever)
        {
            myTransform.localEulerAngles = localAngle; // 回転角度を設定
        }
        else
        {
            myTransform.localEulerAngles = -localAngle; // 回転角度を設定
        }        
    }

    // ダウンイベント
    public void PadDown()
    {
        // マウスポイントのスクリーン座標
        downPos = Input.mousePosition;
        acc = 0;
    }

    // ドラッグイベント
    public void PadDrag()
    {
        // マウスポイントのスクリーン座標
        Vector2 endPos = Input.mousePosition;
        swipeLength = Vector2.Distance(endPos, this.downPos);

        //// 新しいタブの位置を求める
        //Vector2 newTabPos = mousePosition - downPos;// マウスダウン位置からの移動差分
        //if (is4DPad == false)
        //{
        //    newTabPos.y = 0; // 横スクロールの場合は Y 軸を 0 にする
        //}
        //// 移動ベクトルを計算する
        //Vector2 axis = newTabPos.normalized; // ベクトルを正規化する
        //// 2 点の距離を求める
        //float len = Vector2.Distance(defPos, newTabPos);
        //if (len > MaxLength)
        //{
        //    // 限界距離を超えたので限界座標を設定する
        //    newTabPos.x = axis.x * MaxLength;
        //    newTabPos.y = axis.y * MaxLength;
        //}
        //Vector2 newTabPos;
        //newTabPos.x = 0;
        //newTabPos.y = 0;
        //newTabPos.z = swipeLength;
        // タブを移動させる;
        //GetComponent<RectTransform>().localPosition = newTabPos;
        Debug.Log("Coin swipeLength: " + swipeLength);
        //GetComponent<RectTransform>().Rotate(0, 0, swipeLength);
        //GetComponent<RectTransform>().transform.Translate(0, 0, swipeLength);



        // プレイヤーキャラクターを移動させる
        //PlayerController plcnt = player.GetComponent<PlayerController>();
        //plcnt.SetAxis(axis.x, axis.y);
        acc += swipeLength;
    }

    // アップイベント
    public void PadUp()
    {
        float jumpTemp;

        // タブの位置の初期化
        //GetComponent<RectTransform>().localPosition = defPos;
        //GetComponent<RectTransform>().Rotate(0, 0, -acc);
        //GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 1), 0.0f);
        //    // プレイヤーキャラクターを停止させる
        //    PlayerController plcnt = player.GetComponent<PlayerController>();
        //    plcnt.SetAxis(0, 0);

        //jumpTemp = swipeLength / (ForceValue + 1) * 0.1f;
        //jumpTemp = swipeLength * 0.1f;
        jumpTemp = swipeLength / (ForceValue + 1) * 1.0f;
        //jumpTemp = swipeLength * 3.0f;

        if (jumpTemp >= 100.0f)
        {
            jumpTemp = 100.0f;
        }
        player = GameObject.FindGameObjectWithTag("Player");
        CoinController cocnt = player.GetComponent<CoinController>();
        cocnt.Jump(jumpTemp);
        Debug.Log("Coin swipeLength: " + swipeLength + ", ForceValue: " + ForceValue + ", jumpTemp: " + jumpTemp);
        swipeLength = 0;
        jumpTemp = 0;
    }
}