using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_health : MonoBehaviour
{
    public float _maxhealth = 100;
    public float Maxhealth
    {
        get
        {
            return _maxhealth;
        }
        set
        {
            _maxhealth = value;
        }

    }

    public float _health = 100;
    public float Health //������Ϊ�Ƿ���ŵ�����
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }
    public float def = 1;//���˲���
}
