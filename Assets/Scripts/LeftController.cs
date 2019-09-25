using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeftController : MonoBehaviour
{
    [SerializeField]private int left = 4;
    [SerializeField] Text text;

    private void Start()
    {
        text.text = "残機　：　"+left.ToString();
    }

    public void LeftMinus()
    {
        left--;
        Debug.Log(left);
        if (left == -1)
        {
            //GameOver
            Debug.Log("GameOver");
            SceneManager.LoadScene("gameover");
        }
        text.text = "残機　：　" + left.ToString();
    }
}
