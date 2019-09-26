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
        ////一列生成
        //for (int x = 0; x < 20; x++)
        //{
        //    Instantiate(_floarBlock, new Vector3(instantXPos, 4, 0), Quaternion.identity).transform.parent = _fbParent.transform;
        //    blocs.Add(_fbParent.transform.GetChild(x).gameObject);
        //    instantXPos -= 0.5f;
        //}
        ////まばらに生成
        //int posnum = Random.Range(10, 16);
        //for (int y = 0; y <= posnum; y++)
        //{
        //    int instantNum = Random.Range(0, _fbParent.transform.childCount);
        //    if (randomList.Contains(instantNum)) { continue; }
        //    Instantiate(_fbParent.transform.GetChild(instantNum), new Vector3(_fbParent.transform.GetChild(instantNum).position.x, 3.5f, 0), Quaternion.identity).transform.parent = _fbParent.transform;
        //    randomList.Add(instantNum);
        //}
        BFJenerate(1);
        BFJenerate(7);

    }
    public void BFJenerate(float instanceYPos)
    {
        instantXPos = 4.75f;
        for (int x = 0; x < 20; x++)
        {
            //一段目に生成する床
            Instantiate(_floarBlock, new Vector3(instantXPos, instanceYPos, 0), Quaternion.identity).transform.parent = _fbParent.transform;
            instantXPos -= 0.5f;
        }
        int posnum = Random.Range(10, 16);
        for (int y = 0; y <= posnum; y++)
        {
            //二段目に生成する数を0～_fbparentの子の数    
            int instantNum = Random.Range(0, _fbParent.transform.childCount);
            //同じ数字が被らないように
            if (randomList.Contains(instantNum)) { continue; }
            //二段目に生成
            Instantiate(_fbParent.transform.GetChild(instantNum),                                   
                        new Vector3(_fbParent.transform.GetChild(instantNum).position.x, instanceYPos - 0.5f, 0), 
                        Quaternion.identity).transform.parent = _fbParent.transform;
            randomList.Add(instantNum);
        }
    }
}
