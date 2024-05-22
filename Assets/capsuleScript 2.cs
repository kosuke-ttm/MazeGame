using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsuleScript : MonoBehaviour
{
    float speed = 100f;

    float lifeTime = 0.2f;  // 獲得後の生存時間 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ゆっくり回転
        transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
    }
    void OnCollisionEnter(Collision other)
    {
        // プレイヤーが接触で獲得判定
        if (other.gameObject.name == "プレイヤー")
        {
            // コインを上にポップさせる
            transform.position += Vector3.up * 1.5f;

            // 一定時間後に消滅
            Destroy(gameObject);
        }
    }
}
