using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    private Vector3 _playerPos;

    private void Update()
    {
        _playerPos = _player.transform.position;
    }

    public void WarpReverse()
    {
        //左側にいる
        if (_playerPos.x < 0)
        {
            Debug.Log("左側にいる");
            _player.transform.position = new Vector3(6.5f, _playerPos.y, _playerPos.z);

        }
        //右側にいる
        else if (_playerPos.x > 0)
        {
            Debug.Log("右側にいる");
            _player.transform.position = new Vector3(-6.5f, _playerPos.y, _playerPos.z);
        }

    }


}
