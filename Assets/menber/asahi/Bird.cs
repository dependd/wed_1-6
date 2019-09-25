using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Enemy
{
    // Start is called before the first frame update
    void Start(){
        
    }
    
    protected override void Move(){
        this.transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
    }

    protected override void DownMove(){

        this.transform.position += new Vector3(0.0f, -2 * Time.deltaTime, 0.0f);

    }


}
