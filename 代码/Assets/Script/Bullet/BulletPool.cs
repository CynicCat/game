using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletImagePrefab;

    private Queue<GameObject> availableobjects = new Queue<GameObject>();//用队列存储对象

    public static BulletPool Instance { get; private set; }//获取和设置字段（属性）的值
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        GrowPool();
    }
    private void GrowPool()
    {
        for (int i = 0; i < 10; i++)
        {
            var instanceToAdd = Instantiate(BulletImagePrefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }
    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableobjects.Enqueue(instance);
    }
    public GameObject GetFromPool()
    {
        if (availableobjects.Count == 0)
        {
            GrowPool();
        }
        var instance = availableobjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }

    // Update is called once per frame
}
