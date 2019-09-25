using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageUp : MonoBehaviour
{
    [SerializeField]int upLength;
    float time;
    [SerializeField]Cameratest cmr;

    private void OnTriggerStay(Collider other)
    {
        time += Time.deltaTime;
        if(time >= 1.6f)
        {
            cmr.UpStage(upLength);
        }
    }
    private void OnTriggerExit(Collider other)
    {

        time = 0;
    }
}
