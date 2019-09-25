using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Rigidbody rg;

    float MoveSpeed = 10 / 4;
    float speed;

    public bool isAction,isAir;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = rg.velocity.magnitude;
        //ジャンプ
        if (Input.GetKeyDown(KeyCode.X) && !isAction && !isAir)
        {
            rg.AddForce(new Vector3(0, 500, 0));
            MoveSpeed = MoveSpeed / 4;
        }
        //ハンマー
        else if (Input.GetKeyDown(KeyCode.Z) && !isAction && !isAir)
        {

            //ハンマー攻撃の関数
        }

        //スピードに制限をかける
        if (speed >= 2 || isAction) return;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rg.AddForce(new Vector3(MoveSpeed,0,0));
        }else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rg.AddForce(new Vector3(-MoveSpeed, 0, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isAir = false;
        MoveSpeed = MoveSpeed * 4;
    }
    private void OnCollisionExit(Collision collision)
    {
        isAir = true;
    }
    
    IEnumerator PAttack()
    {
        yield return new WaitForSeconds(0.25f);
        GameObject obj = new GameObject();  //攻撃用コライダーがついてるオブジェクトにする
        obj.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        obj.SetActive(false);
    }
}
