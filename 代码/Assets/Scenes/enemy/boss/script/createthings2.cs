using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createthings2 : MonoBehaviour
{
    public GameObject thing;
    public int thingnum = 5;//数量
    private int thingcount = 0;//计数器
    Rigidbody2D myrb;
    boss_s Boss;
    private void Start()
    {
        thingcount = 0;
        Boss = GetComponent<boss_s>();

    }
    private void creatething2()
    {
        if (thingcount > thingnum)
            thingcount = 0;
        Vector2 randpos = Boss.transform.position;
        while (thingcount <= thingnum)
        {
            randpos.y += 2f;
            if (Boss.transform.localScale.x < 0)
                thing.transform.localScale = new Vector2(thing.transform.localScale.x * -1, thing.transform.localScale.y);
            Instantiate(thing, randpos, Quaternion.identity);
            thingcount++;
        }

    }
}
