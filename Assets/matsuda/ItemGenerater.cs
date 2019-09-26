using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerater : MonoBehaviour
{
    [SerializeField] GameObject Item;
    [SerializeField] Vector3[] GeneratePos = new Vector3[8]; 
    
    public void GenerateItem()
    {
        for (int i= 0;i < 4;i++)
        {
            int rnd = Random.Range(0,9);
            Instantiate(Item, GeneratePos[rnd], Quaternion.identity);
        }
    }
}
