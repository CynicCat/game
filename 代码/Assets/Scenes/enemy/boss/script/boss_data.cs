using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_data : enemy_data
{
    PolygonCollider2D polygonCollider2D;
    Renderer myrend;
    public int blinks=2; //闪烁次数
    public float time=1;//闪烁时间
    private bool IfCoroutineDB;
    private bool IfCoroutineSHB;
    private void Awake()
    {
        base.Awake();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        myrend = GetComponent<Renderer>();
        IfCoroutineDB = false;
        IfCoroutineSHB = false;
    }
    public float Health //生命作为是否活着的依据
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
            if (_health > _maxhealth)
            {
                _health = _maxhealth;
            }
        }
    }
    public bool Damage(object[] message)//被击中
    {
        float damage = (float)message[0];
        float AttackPosX = (float)message[1];
        float AttackPosY = (float)message[2];
        int[] buff = new int[4];
        for (int i = 0; i < 4; i++)
            buff[i] = (int)message[i + 3];
        Debug.Log(buff[0]);
        addBuff(buff[0], buff[1], buff[2], buff[3]);
        if (IsAlive && !isinvincible)
        {
            Health -= damage*def;
            isinvincible = true;
            polygonCollider2D.enabled = false;
            BlinkBoss(blinks, time);
            if (IfCoroutineSHB)
            {
                StopCoroutine("ShowHitBox");
                IfCoroutineSHB = false;
            }
            StartCoroutine("ShowHitBox");
            IfCoroutineSHB = true;
            return true;
        }
        //没有击中
        return false;
    }
    void BlinkBoss(int numBlinks, float seconds)//受伤闪烁
    {
        float[] num;
        num = new float[2];
        num[0] = numBlinks;
        num[1] = seconds;
        if (IfCoroutineDB)
        {
            StopCoroutine("DoBlinks");
            IfCoroutineDB = false;
        }
        StartCoroutine("DoBlinks",num);
        IfCoroutineDB = true;
    }

    IEnumerator ShowHitBox()//受伤检测
    {
        yield return new WaitForSeconds(invincibilityTimer);
        polygonCollider2D.enabled = true;
    }

    IEnumerator DoBlinks(float[] num)//受伤闪烁
    {
        for (int i = 0; i < (int)num[0] * 2; i++)
        {
            myrend.enabled = !myrend.enabled;
            yield return new WaitForSeconds(num[1]);
        }
        myrend .enabled = true;
    }
    private void addBuff(int fire, int ice, int posion, int explode)//用于添加buff
    {
        if (fire > 0)
        {
            if (!GetComponent<EnemyBuffFire>())
            {
                gameObject.AddComponent<EnemyBuffFire>().Setup(GetComponent<enemy_health>(), GetComponent<enemy_walk>(), 3, fire).Launch();
                GameObject iceBuffPrefab = Resources.Load<GameObject>("BuffImage/fire");
                //GameObject newiceBuffPrefab = Instantiate(iceBuffPrefab, BuffBarStaus.transform.position, new Quaternion(0, 0, 0, 0));
                //newiceBuffPrefab.transform.SetParent(BuffBarStaus, false);
                //newiceBuffPrefab.transform.position = new Vector2(BuffBarStaus.position.x, BuffBarStaus.position.y);
            }
        }
        if (ice > 0)
        {
            if (!GetComponent<EnemyBuffIce>())
            {
                gameObject.AddComponent<EnemyBuffIce>().Setup(GetComponent<enemy_health>(), GetComponent<enemy_walk>(), 3, ice).Launch();

            }
        }
        if (posion > 0)
        {
            if (!GetComponent<EnemyBuffPosion>())
            {
                gameObject.AddComponent<EnemyBuffPosion>().Setup(GetComponent<enemy_health>(), GetComponent<enemy_walk>(), 3, posion).Launch();
            }
        }
    }
}
