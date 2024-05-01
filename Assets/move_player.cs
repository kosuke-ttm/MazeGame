using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_player : MonoBehaviour
{
    public float jumpPower;
    private Rigidbody rb;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; // 60fps
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
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
            transform.Rotate(0f, 3.0f, 0f);
        }
        if(Input.GetKey("a")) // ←ならY 軸に-5 度回転する
        {
            transform.Rotate(0f, -3.0f, 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // wallタグに設定されているオブジェクトに衝突したらジャンプ復活
        if(collision.gameObject.CompareTag("wall"))
        {
            isJumping = false;
        }
    }
}
