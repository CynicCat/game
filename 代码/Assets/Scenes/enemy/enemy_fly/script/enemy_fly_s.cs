using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class enemy_fly_s : enemy_walk
{
    public float walkToStopRate = 0.1f;//停下来的速率
    public float find_player_dis = 15f;
    public float boomtimes = 1f;
    private Transform player;
    Rigidbody2D myrb;
    SpriteRenderer mysp;
    Animator animator;
    public fly_attackzone Attackzone;
    private void Awake()//创建
    {
        myrb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mysp = GetComponent<SpriteRenderer>();
        //用于寻找player
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Transform>();
    }

    public bool canmove
    {
        get
        {
            return animator.GetBool("canmove");
        }
        private set
        {
            canmove = value;
            animator.SetBool("canmove", value);
        }
    }
    void Update()//检测
    {
        Hastarget = Attackzone.zoneColider.Count > 0;
    }
    public bool _hastarget = false;
    public bool Hastarget
    {
        get { return _hastarget; }
        private set
        {
            _hastarget = value;
            animator.SetBool("hastarget", value);
        }
    }
    private bool _findplayer;
    public bool Findplayer
    {
        get { return _findplayer; }
        private set
        {
            _findplayer = value;
            animator.SetBool(AnimationStrings.findPlayer, value);
        }
    }
    int over = 0;
    protected void FixedUpdate()   
    {
        over += 1;
        if(Hastarget)
            StartCoroutine(boom());
        if (player == null)
        { return; }
        float distance = Vector2.Distance(player.position, myrb.position);
        if (distance < find_player_dis)
        {
            Findplayer = true;
        }
        else
        {
            Findplayer = false;
        }
        if (!Findplayer)
        {
            mysp.color = new Color(0, 0, 0, 1);
        }
        else
        {
            mysp.color = new Color(1, 1, 1, 1);
            if (canmove)
            {
                myrb.transform.position = Vector2.MoveTowards(myrb.transform.position, player.position, walkSpeed * Time.deltaTime);
        }
            else
            Debug.Log("cantmove");
    }

    }
    IEnumerator boom()
    {
        yield return new WaitForSeconds(0.1f);
        mysp.color = new Color32(255, 0, 0, 100);
        yield return new WaitForSeconds(boomtimes);
        animator.SetBool(AnimationStrings.isAlive, false);
        
    }

}