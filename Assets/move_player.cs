using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_player : MonoBehaviour
{
    public float jumpPower;
    private Rigidbody rb;
    private bool isJumping = false;
    [SerializeField] GameObject player;

    [SerializeField]  AudioSource source;
    [SerializeField]  AudioClip clip1;
    [SerializeField]  AudioClip clip2;
    [SerializeField]  AudioClip clip3;
    [SerializeField]  AudioClip clip4;
    [SerializeField]  AudioClip clip5;

    private int musicflag = 0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; // 60fps
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;

        // マウスの移動量を取得
        float mx = Input.GetAxis("Mouse X")*4;
        float my = Input.GetAxis("Mouse Y")*(-4);


        if(pos.y < 16 && musicflag != 1)
        {
            source.Stop();
            source.PlayOneShot(clip1);
            musicflag = 1;
        }
        
        if(16 <= pos.y && pos.y < 53 && musicflag != 2)
        {
            source.Stop();
            source.PlayOneShot(clip2);
            musicflag = 2;
        }
        if(53 <= pos.y && pos.y < 89 && musicflag != 3)
        {
            source.Stop();
            source.PlayOneShot(clip3);
            musicflag = 3;
        }
        if(89 <= pos.y && musicflag != 4)
        {
            source.Stop();
            source.PlayOneShot(clip4);
            musicflag = 4;
        }
        // if(89 <= pos.y && musicflag != 5)
        // {
        //     source.Stop();
        //     source.PlayOneShot(clip5);
        //     musicflag = 5;
        // }

        
        // X方向に一定量移動していれば横回転
        if (Mathf.Abs(mx) > 0.01f)
        {
            // 回転軸はワールド座標のY軸
            transform.RotateAround(player.transform.position, Vector3.up, mx);
        }

        // Y方向に一定量移動していれば縦回転
        if (Mathf.Abs(my) > 0.01f)
        {
            // 回転軸はカメラ自身のX軸
            transform.RotateAround(player.transform.position, transform.right, my);
        }

        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity = Vector3.up * jumpPower;
            isJumping = true;
        }
        if(Input.GetKey("w")) // ↑なら前(Z 方向)に 0.1 だけ進む
        {
            transform.position += transform.forward * 0.08f;
        }
        if(Input.GetKey("s")) // ↓なら後ろ(Z 方向)に 0.1 だけ進む
        {
            transform.position -= transform.forward * 0.08f;
        }
        if(Input.GetKey("d")) // →なら Y 軸に 5 度回転する
        {
            transform.position += transform.right * 0.08f;
            //transform.Rotate(0f, 3.0f, 0f);
        }
        if(Input.GetKey("a")) // ←ならY 軸に-5 度回転する
        {
            transform.position -= transform.right * 0.08f;
            //transform.Rotate(0f, -3.0f, 0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //touch タグのオブジェクトに触れたらジャンプを終了
        if(collision.gameObject.tag == "touch")
        {
            isJumping = false;
        }
    }
}
