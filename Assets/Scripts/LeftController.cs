using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftController : MonoBehaviour
{
    [SerializeField]private int left = 3;
    public void LeftMinus()
    {
        left--;
        Debug.Log(left);
        if (left == -1)
        {
            //GameOver
            Debug.Log("GameOver");
        }
    }
}
