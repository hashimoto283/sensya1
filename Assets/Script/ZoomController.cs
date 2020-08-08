﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    private Camera cam;
    private float zoom;
    private float view;

    void Start()
    {
        cam = GetComponent<Camera>();
        view = cam.fieldOfView;
    }
 
    // Update is called once per frame
    void Update()
    { 
        cam.fieldOfView = view + zoom;
        if(cam.fieldOfView<20f)
        {
            cam.fieldOfView = 20f;
        }
        if (cam.fieldOfView > 60f)
        {
            cam.fieldOfView = 60f;
        }

        // 実際にどのキーを割り当てるかは自由です。
        if (Input.GetKey(KeyCode.RightShift))
        {
            // どれくらいのスピードでズームアップするかは下記で決まる。
            zoom -= 1.2f;

            // 下記のコードがなぜ必要なのか考えてみよう。
            if (zoom < -40f)
            {
                zoom = -40f;
            }
        }
        else // ここでのelseの内容を考えてみよう。
        {
            zoom += 1.2f;

            // 下記のコードがなぜ必要なのか考えてみよう。
            if (zoom > 0)
            {
                zoom = 0;
            }
        }

        // zoomの値がどのように変化するか確認してみよう！
        print("zoomの値" + zoom);
    }
}
    

