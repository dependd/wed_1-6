using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloar : MonoBehaviour
{
    private Vector3 force, _firstPos;   //画面外に出た時に初期値に戻す用
    private bool rdAddCheck;            //rd,firstposの取得チェック
    private Rigidbody rd;

    [SerializeField] private float _moveSpeed = 5f;      //床の動く速度


    private void Update()
    {
        if (!rdAddCheck)
        {
            rd = GetComponent<Rigidbody>();
            _firstPos = this.gameObject.transform.position;
            rdAddCheck = true;
        }
        Floarmove();
    }
    private void Floarmove()
    {
        //床の移動制御
        switch (this.gameObject.name)
        {
            case "MF_RtoL(Clone)":
                transform.position -= transform.right * _moveSpeed * Time.deltaTime;
                if (this.transform.position.x < -8) { transform.position = _firstPos; }
                break;
            case "MF_LtoR(Clone)":
                transform.position += transform.right * _moveSpeed * Time.deltaTime;
                if (this.transform.position.x > 8) { transform.position = _firstPos; }
                break;
        }
    }
    private void OnTriggerEnter(Collider tcolEnter)
    {
        switch(tcolEnter.gameObject.name)
        {
            case "player":
                //playerを動く床の子にする
                tcolEnter.transform.SetParent(this.transform);
                break;
            case "wall":
                break;
        }
    }
    private void OnTriggerExit(Collider tcolExit)
    {
        if(tcolExit.gameObject.name == "player")
        tcolExit.transform.SetParent(null);
    }
}
