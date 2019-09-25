using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameratest : MonoBehaviour
{
    [SerializeField]
    public bool moveON = false;

    [Range(0.01f,1)]
    public float speed;

    [SerializeField]
    public int stageNum;
    public float[] stageHight;
    private float high = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!moveON)
            {
                if (stageHight.Length != stageNum)
                {
                    stageNum++;
                    moveON = true;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (moveON)
        {
            if (transform.position.y < stageHight[stageNum - 1] - 0.5f)
            {
                high += speed;
                transform.position = new Vector3(0, high, -10);
            }
            else if (transform.position.y >= stageHight[stageNum - 1] - 0.5f)
            {
                moveON = false;
            }
        }
    }
}
