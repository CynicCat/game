using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossattack2 : MonoBehaviour
{ 
    Collider2D attackcollider;
    public int attackdamage = 10;//¹¥»÷ÉËº¦
    public Vector2 attackf = Vector2.zero;//¹¥»÷Á¦¶È
    public float movespeed = 15f;
    public float boomtimes = 10f;
    private Transform player;

    PlayerHealth playhealth;
    Animator animator;
    Rigidbody2D myrb;
    private float yy = 0;
    void Start()
    {
        myrb = GetComponent<Rigidbody2D>();
        playhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Transform>();
        animator = GetComponent<Animator>();
        myrb.velocity = new Vector2(0, 3);
        StartCoroutine("boom");
        StartCoroutine("timerun");
        yy = player.position.y;

    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            myrb.transform.localScale = new Vector2(myrb.transform.localScale.x / 2, myrb.transform.localScale.y / 2);
            animator.SetTrigger("boom");
        }

    }
    private void FixedUpdate()
    {
        if (player == null)
            return;
        myrb.transform.position = Vector2.MoveTowards(myrb.transform.position, new Vector2(player.position.x, player.position.y), movespeed * Time.deltaTime);
        if (myrb.transform.position.y <18.1f)
            animator.SetTrigger("boom");
        float newve = player.transform.position.x - myrb.transform.position.x;
        if(newve* myrb.transform.localScale.x < 0)
            myrb.transform.localScale=new Vector2(myrb.transform.localScale.x * -1, myrb.transform.localScale.y);

    }
    IEnumerator boom()
    {
        yield return new WaitForSeconds(boomtimes);
        myrb.transform.localScale = new Vector2(myrb.transform.localScale.x / 2, myrb.transform.localScale.y / 2);
        animator.SetTrigger("boom");

    }
    IEnumerator timerun()
    {
        yield return new WaitForSeconds(0.3f);
        yield return new WaitForFixedUpdate();
    }
}
