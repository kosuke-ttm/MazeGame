using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_player : MonoBehaviour
{
    public float jumpPower;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; // 60fps
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jumpPower;
        }
        if(Input.GetKey("up")) // ↑なら前(Z 方向)に 0.1 だけ進む
        {
            transform.position += transform.forward * 0.1f;
        }
        if(Input.GetKey("down")) // ↓なら後ろ(Z 方向)に 0.1 だけ進む
        {
            transform.position -= transform.forward * 0.1f;
        }
        if(Input.GetKey("right")) // →なら Y 軸に 5 度回転する
        {
            transform.Rotate(0f, 6.0f, 0f);
        }
        if(Input.GetKey("left")) // ←ならY 軸に-5 度回転する
        {
            transform.Rotate(0f, -6.0f, 0f);
        }
    }
}
