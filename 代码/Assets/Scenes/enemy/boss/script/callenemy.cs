using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callenemy : MonoBehaviour
{
    public GameObject[] enemy;
    public int enemynum = 5;//数量
    public float enemytime = 1f;//生成间隔
    private int enemycount = 0;//计数器
    boss_s Boss;
    private void Start()
    {
        enemycount = 0;
        Boss = GetComponent<boss_s>();

    }
    private void createenemy()
    {
        if (enemycount > enemynum)
            enemycount = 0;
        while (enemycount <= enemynum)
        {
            Vector2 randpos = Boss.transform.position;
            randpos.x = randpos.x + Random.Range(2f - Boss.calldis, 2f + Boss.calldis);
            randpos.y = randpos.y + Random.Range(2f, 2f + Boss.calldis);
            int randnum = Random.Range(0, enemy.Length);
            GameObject enemyobject = enemy[randnum];
            Instantiate(enemyobject, randpos, Quaternion.identity);
            enemycount++;
        }
        
    }

}
