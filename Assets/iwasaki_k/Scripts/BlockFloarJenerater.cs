using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFloarJenerater : MonoBehaviour
{
    [SerializeField] private GameObject _floarBlock;
    [SerializeField] private GameObject _fbParent;
    [SerializeField] private float instantXPos = 4.75f;

    private int blockNum;
    
    void Start()
    {
        for(int x = 0; x < 20; x++)
        {
            Instantiate(_floarBlock, new Vector3(instantXPos, 3, 0), Quaternion.identity).transform.parent = _fbParent.transform; ;
            instantXPos -= 0.5f;
        }

    }
    public void BFJenerate(float instanceYPos)
    {
        for (int x = 0; x < 20; x++)
        {
            Instantiate(_floarBlock, new Vector3(instantXPos, instanceYPos, 0), Quaternion.identity).transform.parent = _fbParent.transform; ;
            instantXPos -= 0.5f;
        }
    }
}
