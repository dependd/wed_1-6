using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Rigidbody rg;
    Player playerComp;

    [SerializeField]public float MoveSpeed;
    [SerializeField]float MaxSpeed;
    [SerializeField]float jumpForce;

    public bool isAir;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        playerComp = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        MaxSpeed = rg.velocity.magnitude;
        //ジャンプ
        if (Input.GetKeyDown(KeyCode.X) && !playerComp.isAction && !isAir)
        {
            rg.AddForce(new Vector3(0, jumpForce, 0));
        }
        //ハンマー
        else if (Input.GetKeyDown(KeyCode.Z) && !playerComp.isAction && !isAir)
        {
            playerComp.PAttack();
            //ハンマー攻撃の関数
        }

        //スピードに制限をかける
        if (!isAir && MaxSpeed >= 2 || playerComp.isAction) return;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rg.AddForce(new Vector3(MoveSpeed,0,0));
            transform.localRotation = new Quaternion(0,0,0,0);
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rg.AddForce(new Vector3(-MoveSpeed, 0, 0));
            transform.localRotation = new Quaternion(0, 180, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isAir = false;
        MoveSpeed = MoveSpeed * 10;
    }
    private void OnCollisionExit(Collision collision)
    {
        isAir = true;
        MoveSpeed = MoveSpeed / 10;
    }
    
}
