using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private bool isVisible;
    private Vector3 playerPos = new Vector3(0,-4.3f,0);
    private Vector3 EnemyAtacked;
    [SerializeField]private float timeleft = 0;
    [SerializeField]
    private LeftController leftController;
    private float waitTime = 4f;
    private bool mutekiFlag;
    private bool zankiFlag = false;
    private float mutekiTime = 3.0f;
    private Rigidbody rb;
    private int leftBool = 0;
    private bool bonusStageBool = false;
    private float bonusTime = 40.0f;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mutekiFlag == true)
        {
            if (zankiFlag)
            {
                //anim.SetBool("AttackBool", true);
                leftController.LeftMinus();
                zankiFlag = false;
            }
            //Debug.Log("残り無敵時間"+mutekiTime);
            mutekiTime -= Time.deltaTime;
            if (mutekiTime < 0)
            {
                mutekiTime = 3.0f;
                mutekiFlag = false;
            }
        }

        if (bonusStageBool == true)
        {
            bonusTime -= Time.deltaTime;
            if(bonusTime < 0)
            {
                //gameover
            }
        }

        timeleft -= Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
            Vector2 force = new Vector2(0.5f * 10, 0);   // 力を設定
            rb.AddForce(force);  // 力を加える
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
            Vector2 force = new Vector2(-0.5f * 10, 0);  // 力を設定
            rb.AddForce(force);  // 力を加える
        }
        
        if(isVisible == false)
        {
            leftController.LeftMinus();
            PlayerReBorn();
            isVisible = true;
        }
    }
    void OnBecameInvisible()
    {
        isVisible = false;
        //Debug.Log(playerPos);
        //Debug.Log("映ってない");
    }
    void OnBecameVisible()
    {
        isVisible = true;
        //Debug.Log("映ってる");
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Floor" && timeleft <= 0.0)
        {
            timeleft = 1.3f;
            playerPos = this.gameObject.transform.position;            
            //Debug.Log(playerPos);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" && mutekiFlag == false)
        {                       
            EnemyAtacked = this.gameObject.transform.position;
            StartCoroutine(WaitTime());
        }
    }


    private void PlayerReBorn()
    {
        this.gameObject.transform.position = new Vector3(playerPos.x, playerPos.y, playerPos.z);
    }

    private IEnumerator WaitTime()
    {
        rb.isKinematic = true;
        yield return new WaitForSeconds(waitTime);
        rb.isKinematic = false;
        mutekiFlag = true;
        zankiFlag = true;
        playerPos = EnemyAtacked;
        PlayerReBorn();       
    }
}
