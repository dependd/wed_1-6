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

    private Vector3 force;

    //床の動く速度
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody rd;
    private void Start()
    {
        rd = GetComponent<Rigidbody>();
    }
    private void Update()
    {

        //床の移動制御
        switch (this.gameObject.name)
        {
            case "MF_RtoL":
                transform.position -= transform.right * _moveSpeed * Time.deltaTime;
                break;
            case "MF_LtoR":
                transform.position += transform.right * _moveSpeed * Time.deltaTime;
                break;
        }
    }
    private void OnTriggerEnter(Collider tricol)
    {
    }
}
