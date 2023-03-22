using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImagePool : MonoBehaviour
{
    [SerializeField]
    private GameObject afterImagePrefab;//预制体 

    private Queue<GameObject> availableobjects = new Queue<GameObject>();//用队列存储对象
    // Start is called before the first frame update
    public static PlayerAfterImagePool Instance { get; private set; }//获取和设置字段（属性）的值

    private void Awake()
    {
        Instance= this;
        GrowPool();
    }
    private void GrowPool()
    {
        for(int i=0;i<10;i++)
        {
            var instanceToAdd=Instantiate(afterImagePrefab);//克隆一个预制体
            instanceToAdd.transform.SetParent(transform);//设置转换
            AddToPool(instanceToAdd);//将这个加入到对象池中
        }
    }
    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);//使当前对象不可以
        availableobjects.Enqueue(instance);//在队列里面加入 instance
    }

    public GameObject GetFromPool()
    {
        if(availableobjects.Count == 0) //当对象池中没有的话就GrowPool
        {
            GrowPool();
        }
        var instance= availableobjects.Dequeue();//从队列里面取出
        instance.SetActive(true);//使其可以获得
        return instance;//返回一个对象
    }

}
