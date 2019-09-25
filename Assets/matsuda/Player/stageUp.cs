using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageUp : MonoBehaviour
{
    float time;
    [SerializeField]Cameratest cmr;

    private void OnTriggerStay(Collider other)
    {
        time += Time.deltaTime;
        if(time >= 1.6f)
        {
            if (!cmr.moveON)
            {
                if (cmr.stageHight.Length != cmr.stageNum)
                {
                    cmr.stageNum++;
                    cmr.moveON = true;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        time = 0;
    }
}
