using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createthings3 : MonoBehaviour
{

    public GameObject thing;
    public int thingnum = 4;//数量
    private int thingcount = 0;//计数器
    public float createtime = 1;
    Rigidbody2D myrb;
    private Transform player;
    private void Start()
    {
        thingcount = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Transform>();
    }
    private void creatething3()
    {
        if (player == null)
            return;
        if (thingcount > thingnum)
            thingcount = 0;
        
        while (thingcount <= thingnum)
        {
            Vector2 randpos =player.position;
            StartCoroutine("waittime");
            randpos.y *= 1.5f;
            Instantiate(thing, randpos, Quaternion.identity);
            StopCoroutine("waittime");
            thingcount++;
        }
    }
    IEnumerator waittime()
    {

        yield return new WaitForSeconds(createtime);
    }
}
