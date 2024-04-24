using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class contact : MonoBehaviour // この行はコピーしてはいけない.元のスクリプトのままにする.
{
    [SerializeField]
    private TextMeshProUGUI TextTime;
    private float elapsedTime;

    // ゴールに到達した時に1となるフラグを追加する
    private int f_gall;

    private int collision;


    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0.0F;
        f_gall = 0; // 停止フラグを初期化する
        collision = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TextTime.text = string.Format("CollisionCount:" + collision);
    }

    // 衝突を判定する処理を追加する
    void OnCollisionEnter(Collision wall) // 衝突を判定する関数を呼ぶ
    {
        if (wall.transform.root.gameObject.name == "wall") // 衝突した物体が「ゴール」なら(※)
        {
            collision += 1;
        }
    }
}
