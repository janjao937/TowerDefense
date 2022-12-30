using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    [SerializeField] private int objectCapacity = default;
    [SerializeField] private GameObject poolingObject = default;
    private List<GameObject> poolingList = new List<GameObject>();
    private int poolingIndex = 0;
    
    private void Awake() 
    {
        CreatePoolingObject();
    }
    private void CreatePoolingObject()
    {
        for(int i = 0 ; i < objectCapacity ; i++)
        {
            var p  = Instantiate(poolingObject,transform);
            p.SetActive(false);
            poolingList.Add(p);
        }
    }
    public GameObject GetFromPool()
    {
        if(poolingIndex < poolingList.Count-1)
        {
            poolingIndex++;
        }else poolingIndex = 0;
       // poolingList[poolingIndex].SetActive(true);

        return poolingList[poolingIndex];
    }
  
}
