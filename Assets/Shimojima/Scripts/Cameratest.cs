﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameratest : MonoBehaviour
{
    [SerializeField]
    private bool moveON = false;
    public GameObject a;

    [Range(0.01f,1)]
    public float speed;

    [SerializeField]
    private int stageNum;
    public GameObject[] stageHight;
    private float high = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!moveON && stageNum != stageHight.Length + 3)
            {
                stageNum++;
                a.transform.position = new Vector3(0, a.transform.position.y + 2.5f, 0);
                if (stageNum >= 4)
                {
                    moveON = true;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (moveON)
        {
            if (transform.position.y < stageHight[stageNum - 4].transform.position.y - 0.5f)
            {
                high += speed;
                transform.position = new Vector3(0, high, -10);
            }
            else if (transform.position.y >= stageHight[stageNum - 4].transform.position.y - 0.5f)
            {
                moveON = false;
            }
        }
    }
}
