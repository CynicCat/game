using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createthings : MonoBehaviour
{
    public GameObject thing;
    public int thingnum = 5;//数量
    private int thingcount = 0;//计数器
    boss_s Boss;
    private void Start()
    {
       thingcount = 0;
        Boss = GetComponent<boss_s>();

    }
    private void creatething()
    {
        if (thingcount > thingnum)
            thingcount = 0;
        while (thingcount <= thingnum)
        {
            Vector2 randpos = Boss.transform.position;
            randpos.x = randpos.x + Boss.transform.localScale.x * 0.1f;
            Instantiate(thing, randpos, Quaternion.identity);
            thingcount++;
        }

    }
}
