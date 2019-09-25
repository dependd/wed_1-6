using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondorMove : MonoBehaviour
{
    private Vector3 _condorPos = new Vector3(0,38,0);

    [SerializeField]
    private float _timeOut;
    [SerializeField]
    private float _condorSpeed = 1;
    [SerializeField]
    private float _condorReturnPos = 8;

    private float _changeTime = 0f;

    private int vector = 0;

    private void Start()
    {
    }

    void Update()
    {
        transform.position = _condorPos;
        MoveVector();
        //Debug.Log(vector);

        switch (vector)
        {
            case 1:
            case 3:
            case 5:
                _condorPos.x += _condorSpeed;
                break;

            case 0:
            case 2:
            case 4:
                _condorPos.x -= _condorSpeed;
                break;
        }

        if (_condorPos.x > 8)
        {
            _condorPos = new Vector3(-_condorReturnPos, _condorPos.y, _condorPos.z);
        }
        else if (_condorPos.x < -8)
        {
            _condorPos = new Vector3(_condorReturnPos, _condorPos.y, _condorPos.z);
        }
    }


    private void MoveVector()
    {
        _changeTime += Time.deltaTime;

        if (_changeTime >= _timeOut)
        {
            vector = Random.Range(0, 6);
            _changeTime = 0f;
        }
    }
}
