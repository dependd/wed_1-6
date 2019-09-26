using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFJenerater : MonoBehaviour
{
    [SerializeField] private GameObject[] _floar;
    //intの値に呼び出す動く床の番号(0番が左から動く床/1番が右から動く床)
    //[0番のvec3が(-8,0,0)]/[1番のvec3が(8,0,0)]
    public void MFJenerate(int num,Vector3 _floarPos,float speed)
    {
        var obj = Instantiate(_floar[num], _floarPos, Quaternion.identity);
        obj.GetComponent<MoveFloar>()._moveSpeed = speed;
    }
    private void Update()
    {
        //instantiateの確認用
        Debug();
    }
    private void Start()
    {

        MFJenerate(0, new Vector3(-8, -2, 0), 2);
        MFJenerate(1,new Vector3(8,10,0),2);
        MFJenerate(1, new Vector3(8, 22, 0),4);
        MFJenerate(0, new Vector3(-8, 28, 0),5);
    }
    void Debug()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MFJenerate(0, new Vector3(-8, 0, 0),1);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            MFJenerate(0, new Vector3(-8, 2, 0),1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            MFJenerate(0, new Vector3(-8, 4, 0),1);
        }
    }
}