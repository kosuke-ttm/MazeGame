using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayGall : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI DisplayGallText;

    // ゴールに到達した時に1となるフラグを追加する
    private int f_gall;
    // Start is called before the first frame update
    void Start()
    {
        f_gall = 0; // 停止フラグを初期化する
    }

    // Update is called once per frame
    void Update()
    {
        if (f_gall != 0) // ゴールに到達していない場合だけ時間を加算する
        {
            DisplayGallText.text = string.Format("Gall!");
        }
    }

    // 衝突を判定する処理を追加する
    void OnCollisionEnter(Collision other) // 衝突を判定する関数を呼ぶ
    {
        if (other.gameObject.name == "Cylinder") // 衝突した物体が「ゴール」なら(※)
        {
            f_gall = 1; // 衝突フラグを上げる
        }
    }
}
