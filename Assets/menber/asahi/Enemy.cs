using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//エネミーの基礎クラス
public abstract class Enemy : MonoBehaviour
{

    //飛行タイプかどうか
    protected bool flyType = false;

    //移動速度
    public float speed = 1.0f;

    


    //やられているか
    protected bool down = false;

    public bool downFlag{
        get { return down; }
    }
    

    // Update is called once per frame
   　public virtual void Update()
    {
        if (!downFlag) {
            Move();
        }
        else if(downFlag){
            DownMove();
        }
    }

    protected abstract void Move();

    protected abstract void DownMove();

    //ハンマーが当たったらダウン状態に
    public void Down() {
        down = true;
    }

    public void OnBecameInvisible(){
        //Debug.Log("ドカーン");
        Destroy(this.gameObject);
    }

}
