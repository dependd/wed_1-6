using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Spownpoint { 右, 左 }

public class SeaLionSpowner : MonoBehaviour
{

    [SerializeField]
    Spownpoint spownpoint;

    [SerializeField]
    GameObject spownEnemy;

    [SerializeField]
    float speed = 1.0f;

    float Timer = 0;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if(this.transform.childCount == 0){
            if(Timer > 1) {
                Timer = 0;
                Spown();
            }else{
                Timer += Time.deltaTime;
            }
            
        }

    }

    void Spown(){
        GameObject enemy = Instantiate(spownEnemy,this.transform);
        enemy.transform.parent = this.transform;
        Enemy newEnemy = enemy.GetComponent<Enemy>();
        newEnemy.speed = speed;
        if (spownpoint == Spownpoint.右) {
            Debug.Log("ミギダヨ");
            newEnemy.speed = speed *-1;
            Debug.Log(enemy.GetComponent<Enemy>().speed);
        }
    }

}
