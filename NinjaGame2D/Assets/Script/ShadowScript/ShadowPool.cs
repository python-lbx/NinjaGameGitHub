using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour
{
    public static ShadowPool instance;

    public GameObject shadowPrefab;

    public int shadowCount;

    Queue<GameObject> availableObjects = new Queue<GameObject>();

    private void Awake() 
    {
        instance = this;

        //初始化對象池
        FillPool();
    }

    public void FillPool()
    {
        for(int i = 0;i < shadowCount; i++)
        {
            var newShadow = Instantiate(shadowPrefab);
            newShadow.transform.SetParent(transform);

            //取消啟用,返回對象池
            ReturnPool(newShadow);
        }
    }

    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);

        availableObjects.Enqueue(gameObject);
    }
    
    public GameObject GetFormPool()
    {
        if(availableObjects.Count == 0)
        {
            FillPool();
        }
        var outShadow = availableObjects.Dequeue();

        outShadow.SetActive(true);

        return outShadow;
    }
}
