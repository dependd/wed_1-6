using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Hammer;   
    public bool isAction;   //アクション中か

    int playerStock;    //残機

    [SerializeField]Cameratest cmr;
    // Start is called before the first frame update
    void Start()
    {
        playerStock = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    ///攻撃の処理関数
    /// </summary>
    public void PAttack()
    {
        Hammer.GetComponent<Animator>().SetTrigger("attack");
        isAction = true;
        StartCoroutine(HammerAttack());
    }
    /// <summary>
    /// 攻撃の関数
    /// </summary>
    /// <returns></returns>
    IEnumerator HammerAttack()
    {
        BoxCollider col = Hammer.GetComponent<BoxCollider>();
        col.enabled = true;
        yield return new WaitForSeconds(0.25f);
        col.enabled = false;
        isAction = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //コライダーに当たった時の処理類を作っていく
        switch (collision.gameObject.name) {
            case "SeaLion":
                if (collision.gameObject.GetComponent<Enemy>().downFlag) return;
                Debug.Log("ぎゃあああ");
                //残機へらす処理
                break;
            case "":
                break;
            case "Condor":
                Debug.Log("Goal!!");
                break;
        }

        //敵に当たったら
        //ゴールの鳥に当たったら
        //
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            //スコア加算
            Destroy(other.gameObject);
        }
    }

}
