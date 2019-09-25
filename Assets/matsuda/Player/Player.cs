﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Hammer;
    public bool isAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PAttack()
    {
        Hammer.GetComponent<Animator>().SetTrigger("attack");
        isAction = true;
        StartCoroutine(HammerAttack());
    }
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
    }
}
