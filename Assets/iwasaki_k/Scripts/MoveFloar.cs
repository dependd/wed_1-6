using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 移動する足場
/// </summary>
public class MoveFloar : MonoBehaviour
{
    //子にするためのプレイヤーを格納する
    private GameObject _childPlayer;

    private Vector3 force, _firstPos;

    private bool rdAddCheck;
    //床の動く速度
    [SerializeField] private float _moveSpeed = 5f;

    [HideInInspector] public Rigidbody rd;
    private void Update()
    {
        if (!rdAddCheck)
        {
            rd = GetComponent<Rigidbody>();
            _firstPos = this.gameObject.transform.position;
            rdAddCheck = true;
        }
        //床の移動制御
        switch (this.gameObject.name)
        {
            case "MF_RtoL(Clone)":
                //Debug.Log("呼ばれてる");
                transform.position -= transform.right * _moveSpeed * Time.deltaTime;
                if (this.transform.position.x < -8) { transform.position = _firstPos; }
                break;
            case "MF_LtoR(Clone)":
                transform.position += transform.right * _moveSpeed * Time.deltaTime;
                if (this.transform.position.x > 8) { transform.position = _firstPos; }
                break;
        }
    }
}
