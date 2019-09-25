using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//エネミーの基礎クラス
public abstract class Enemy : MonoBehaviour
{

    //飛行タイプかどうか
    protected bool flyType = false;

    //移動速度
    protected float speed = 1.0f;

    public float enemySpeed {
        get { return speed; }
        set { speed = enemySpeed; }
    }


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

    public void Down() {
        down = true;
    }
    public void OnBecameInvisible(){
        Debug.Log("ドカーン");
        Destroy(this.gameObject);
    }

}
