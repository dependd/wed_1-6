using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaLion : Enemy
{

    float startspeed;

    Quaternion startQuaternion;
    // Start is called before the first frame update
    void Start(){
        startspeed = speed;
        startQuaternion = this.transform.rotation;
    }

    public override void Update(){
        
        base.Update();
    }


    protected override void Move(){
        if (FloorCheck()) {
            this.transform.Rotate(new Vector3(0, 180, 0));
            speed = speed * -1;
        }
        //一秒でspeed分移動
        this.transform.position += new Vector3(speed*Time.deltaTime , 0.0f, 0.0f) ;
    }

    protected override void DownMove(){
        this.transform.rotation = startQuaternion;
        if (speed != startspeed){ speed = startspeed; }
        //一秒でspeed分移動
        this.transform.position += new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f);
    }
    //床のチェック関数
    bool FloorCheck(){
        float i = 1.15f;
        if(speed < 0){ i = i * -1; }
        Vector3 point = this.transform.position + new Vector3(i, -0.9f, 0);
        if (!Physics.CheckSphere(point, 0.01f)) {
            return true;
        }
        return false;
    }

}
