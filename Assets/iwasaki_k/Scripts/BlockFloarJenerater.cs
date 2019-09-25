using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFloarJenerater : MonoBehaviour
{
    [SerializeField] private GameObject _floarBlock;
    [SerializeField] private GameObject _fbParent;
    [SerializeField] private float instantXPos = 4.75f;

    private List<int> randomList = new List<int>();
    private List<GameObject> blocs = new List<GameObject>();
    private int blockNum;

    void Start()
    {
        //一列生成
        for (int x = 0; x < 20; x++)
        {
            Instantiate(_floarBlock, new Vector3(instantXPos, 4, 0), Quaternion.identity).transform.parent = _fbParent.transform;
            blocs.Add(_floarBlock);
            instantXPos -= 0.5f;
        }
        //まばらに生成
        int posnum = Random.Range(5, 14);
        for (int y = 0; y <= posnum; y++)
        {
            int instantNum = Random.Range(0, _fbParent.transform.childCount);
            if (randomList.Contains(instantNum)) { continue; }
            Instantiate(blocs[instantNum], new Vector3(, 3.5f, 0), Quaternion.identity);
            randomList.Add(instantNum);
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
