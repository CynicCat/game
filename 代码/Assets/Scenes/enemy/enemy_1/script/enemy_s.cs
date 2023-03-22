using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(Rigidbody2D),typeof(touchingdirection))]
public class enemy_s : enemy_walk
{
    public float walkToStopRate = 0.1f;//停下来的速率
    public attackzone Attackzone;
    public attack2zone Attack2zone;
    public float findplayerdis=15f;
    public enum WalkableDirection{Right,Left};//记录移动方向
    private WalkableDirection _walkdirecton;
    private Vector2 enemy_walkdirectionVector = Vector2.left;//走路方向矢量   
    private Transform player;
    touchingdirection touchingdirections;
    Rigidbody2D myrb;
    Animator animator;
    public findEdgeZone findedgezone;
    private void Awake()//创建
    {
        myrb = GetComponent<Rigidbody2D>();
        touchingdirections = GetComponent<touchingdirection>();
        animator = GetComponent<Animator>();
        //用于寻找player
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Transform>();
    }

    public bool _hastarget = false;
    public bool Hastarget { get { return _hastarget; }
        private set
        {
            _hastarget = value;
            animator.SetBool("hastarget", value);
        }
    }
    public bool _hastarget2 = false;
    public bool Hastarget2 
    { get { return _hastarget2; }
        private set 
        {
            _hastarget2 = value;
            animator.SetBool(AnimationStrings.hasTarget2, value);
        }
    }
    public bool canmove
    {
        get
        {
            return animator.GetBool("canmove");
        }
        private set
        { canmove = value;
            animator.SetBool("canmove", value);
        }
    }

   public float AttackCooldown 
    { get 
        { return animator.GetFloat(AnimationStrings.Attackcooldown); }
        private set 
        {
            animator.SetFloat(AnimationStrings.Attackcooldown,MathF.Max(value,0));
        } }

    public float Attack2Cooldown
    {
        get
        { return animator.GetFloat(AnimationStrings.Attack2cooldown); }
        private set
        {
            animator.SetFloat(AnimationStrings.Attack2cooldown, MathF.Max(value, 0));
        }
    }
    void Update()//检测
    {
        //检测攻击区域是否有Colider
        Hastarget = Attackzone.zoneColider.Count > 0;
        Hastarget2 = Attack2zone.zone2Colider.Count > 0;
        AttackCooldown -= Time.deltaTime;
        Attack2Cooldown -= Time.deltaTime;
    }
    public WalkableDirection walkdirection //判断是否移动转向
    {
        get { return _walkdirecton; }
        set {
            if (_walkdirecton != value)
            {//转向
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x*-1 , gameObject.transform.localScale.y);
                if (value == WalkableDirection.Right)
                {
                    enemy_walkdirectionVector = Vector2.right;
                }
                else if (value == WalkableDirection.Left)
                { enemy_walkdirectionVector = Vector2.left; }
            }
            _walkdirecton = value; 
        
        }
    }

    private bool _findplayer;
    public bool Findplayer
    {
        get { return _findplayer; }
        private set
        {
            _findplayer = value;
            animator.SetBool(AnimationStrings.findPlayer,value);
        }
    }
    int over=0;
    protected void FixedUpdate()    //图形反转
    {
        over += 1;
        if (player == null)
        { return; }
        float distance = Vector2.Distance(player.position, myrb.position);
        if (distance < findplayerdis)
        {
            Findplayer = true;
        }
        else
        {
            Findplayer = false;
        }
        if (!Findplayer)
        {
            if ((animator.GetBool("isground") && animator.GetBool("isonwall") || findedgezone.zoneColider.Count == 0))
            {
                FilpDirection();

            }
            if (canmove)
                //速度矢量
                myrb.velocity = new Vector2(walkSpeed * enemy_walkdirectionVector.x, myrb.velocity.y);
            else
                myrb.velocity = new Vector2(Mathf.Lerp(myrb.velocity.x, 0, walkToStopRate), myrb.velocity.y);
        }
        else
        {
            float newve = player.transform.position.x - myrb.transform.position.x;
            if (findedgezone.zoneColider.Count != 0)
            {
                if (newve * myrb.transform.localScale.x < 0)
                {
                    if (canmove)
                        myrb.velocity = new Vector2(walkSpeed * enemy_walkdirectionVector.x, myrb.velocity.y);
                    else
                        myrb.velocity = new Vector2(Mathf.Lerp(myrb.velocity.x, 0, walkToStopRate), myrb.velocity.y);
                    if (over >= 18)
                    {
                        FilpDirection();
                        over = 0;
                    }

                }
                else if (newve * myrb.transform.localScale.x > 0)
                {
                    if (canmove)
                        myrb.velocity = new Vector2(walkSpeed * enemy_walkdirectionVector.x, myrb.velocity.y);
                    else
                        myrb.velocity = new Vector2(Mathf.Lerp(myrb.velocity.x, 0, walkToStopRate), myrb.velocity.y);
                }
                else
                {
                    myrb.velocity = new Vector2(Vector2.zero.x, myrb.velocity.y);
                }
            }
            else
            {
                myrb.velocity = new Vector2(Vector2.zero.x, myrb.velocity.y);
            }
        }

    }

    protected void  FilpDirection()  //图形方向翻转
    {
        
        if (walkdirection == WalkableDirection.Right)
        {
            walkdirection= WalkableDirection.Left;
        }
        else if (walkdirection == WalkableDirection.Left)
        {
            walkdirection = WalkableDirection.Right;
        }
        else { Debug.LogError("未设置方向");  }
    }



}
