using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemy_data : enemy_health
{
    Animator animator;
    protected void Awake()
    {
        animator = GetComponent<Animator>();
    }
    [SerializeField]
    protected bool isinvincible;//�Ƿ��޵�

    public bool isHit { get
        {
            return animator.GetBool(AnimationStrings.isHit);
        }
        private set { animator.SetBool(AnimationStrings.isHit,value); } }
    protected float timeSinceHit=0;
    public float invincibilityTimer=0.05f;

    public float Health //������Ϊ�Ƿ���ŵ�����
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;

            if (_health <= 0)
            {
                IsAlive = false;
            }
        }
    }


    public bool Damage(object[] message)//������
    {
        float damage = (float)message[0];
        float AttackPosX = (float)message[1];
        float AttackPosY = (float)message[2];
        int[] buff=new int[4];
        for (int i = 0; i < 4; i++)
            buff[i] = (int)message[i + 3];
        Debug.Log(buff[0]);
        addBuff(buff[0], buff[1], buff[2], buff[3]);
        if (IsAlive && !isinvincible)
        {
            Health -= damage*def;
            isinvincible = true;
            animator.SetTrigger(AnimationStrings.hitTrigger);
            //damageableHit?.Invoke(damage, attackf);
            return true;
        }
        //û�л���
            return false;
    }

    [SerializeField]
    protected bool _isAlive = true;
    public bool IsAlive//�ж�����
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("isalive" + value);
        }
    }
    public void Update()
    {
        if (isinvincible)
        { 
            if (timeSinceHit > invincibilityTimer) 
            {
                isinvincible = false;
                timeSinceHit = 0;
            }
            timeSinceHit += Time.deltaTime;
        }
    }

    private void addBuff(int fire,int ice,int posion,int explode)//�������buff
    {
        if(fire>0)
        {
            if (!GetComponent<EnemyBuffFire>())
            {
                gameObject.AddComponent<EnemyBuffFire>().Setup(GetComponent<enemy_health>(),GetComponent<enemy_walk>(), 3, fire).Launch();
                GameObject iceBuffPrefab = Resources.Load<GameObject>("BuffImage/fire");
                //GameObject newiceBuffPrefab = Instantiate(iceBuffPrefab, BuffBarStaus.transform.position, new Quaternion(0, 0, 0, 0));
                //newiceBuffPrefab.transform.SetParent(BuffBarStaus, false);
                //newiceBuffPrefab.transform.position = new Vector2(BuffBarStaus.position.x, BuffBarStaus.position.y);
            }
        }
        if(ice>0)
        {
            if(!GetComponent<EnemyBuffIce>())
            {
                gameObject.AddComponent<EnemyBuffIce>().Setup(GetComponent<enemy_health>(), GetComponent<enemy_walk>(), 3, ice).Launch();

            }
        }
        if(posion>0)
        {
            if(!GetComponent<EnemyBuffPosion>())
            {
                gameObject.AddComponent<EnemyBuffPosion>().Setup(GetComponent<enemy_health>(), GetComponent<enemy_walk>(), 3, posion).Launch();
            }
        }
    }
}
