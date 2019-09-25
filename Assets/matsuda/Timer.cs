using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public int MaxTime;
    float time;
    [SerializeField]Text leftTime;
    [SerializeField] Text maxTime;

    // Start is called before the first frame update
    void Start()
    {
        time = (int)MaxTime;
        maxTime.text = MaxTime.ToString();
        leftTime.text = time.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time -= Time.deltaTime;
        leftTime.text = time.ToString();
        if (time <= 0)
        {
            SceneManager.LoadScene("gameover");
        }
    }
}
