using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFJenerater : MonoBehaviour
{
    [SerializeField] private GameObject[] _floar;
    //intの値に呼び出す動く床の番号(0番が左から動く床/1番が右から動く床)
    //[0番のvec3が(-8,0,0)]/[1番のvec3が(8,0,0)]
    public void MFJenerate(int num,Vector3 _floarPos)
    {
        Instantiate(_floar[num], _floarPos, Quaternion.identity);
    }
    private void Update()
    {
        //instantiateの確認用
        Debug();
    }
    private void Start()
    {
        Instantiate(_floar[0], new Vector3(-8, -2, 0), Quaternion.identity);
        
        MFJenerate(1,new Vector3(8,10,0));
        MFJenerate(1, new Vector3(8, 22, 0));
        MFJenerate(0, new Vector3(-8, 28, 0));
    }
    void Debug()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MFJenerate(0, new Vector3(-8, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            MFJenerate(0, new Vector3(-8, 2, 0));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            MFJenerate(0, new Vector3(-8, 4, 0));
        }
    }
}