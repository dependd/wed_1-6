using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    private Vector3 _playerPos;

    [Header("7位が目安")]
    [SerializeField]
    private float _reversePos;

    private void Update()
    {
        _playerPos = _player.transform.position;
        WarpReverse();
    }

    public void WarpReverse()
    {
        //左側にいる
        if (_playerPos.x < -6.5)
        {
            Debug.Log("左側にいる");
            _player.transform.position = new Vector3(_reversePos, _playerPos.y, _playerPos.z);

        }
        //右側にいる
        else if (_playerPos.x > 6.5)
        {
            Debug.Log("右側にいる");
            _player.transform.position = new Vector3(-_reversePos, _playerPos.y, _playerPos.z);
        }

    }


}
