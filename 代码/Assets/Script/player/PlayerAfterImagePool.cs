using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImagePool : MonoBehaviour
{
    [SerializeField]
    private GameObject afterImagePrefab;//Ԥ���� 

    private Queue<GameObject> availableobjects = new Queue<GameObject>();//�ö��д洢����
    // Start is called before the first frame update
    public static PlayerAfterImagePool Instance { get; private set; }//��ȡ�������ֶΣ����ԣ���ֵ

    private void Awake()
    {
        Instance= this;
        GrowPool();
    }
    private void GrowPool()
    {
        for(int i=0;i<10;i++)
        {
            var instanceToAdd=Instantiate(afterImagePrefab);//��¡һ��Ԥ����
            instanceToAdd.transform.SetParent(transform);//����ת��
            AddToPool(instanceToAdd);//��������뵽�������
        }
    }
    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);//ʹ��ǰ���󲻿���
        availableobjects.Enqueue(instance);//�ڶ���������� instance
    }

    public GameObject GetFromPool()
    {
        if(availableobjects.Count == 0) //���������û�еĻ���GrowPool
        {
            GrowPool();
        }
        var instance= availableobjects.Dequeue();//�Ӷ�������ȡ��
        instance.SetActive(true);//ʹ����Ի��
        return instance;//����һ������
    }

}
