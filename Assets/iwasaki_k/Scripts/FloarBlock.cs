using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloarBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            other.gameObject.GetComponent<PlayerInput>().MoveSpeed = other.gameObject.GetComponent<PlayerInput>().MoveSpeed / 10;
            Destroy(this.gameObject);
        }
    }
}
