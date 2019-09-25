using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //エネミーのコンポーネント取得
        if (other.gameObject.GetComponent<Enemy>() == null) return;
        //取得ができたらDown関数を呼んで、終わり！！
        other.gameObject.GetComponent<Enemy>().Down();
    }
}
