using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossattack1 : MonoBehaviour
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
    public int[] buff = new int[3];
    void Start()
    {
        myrb = GetComponent<Rigidbody2D>();
        playhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        player = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<Transform>();
        StartCoroutine(boom());
        yy = player.position.y;
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            playhealth.DamagePlayer(attackdamage, Vector2.zero);
            object[] message = new object[3];
            message[0] = buff[0];
            message[1] = buff[1];
            message[2] = buff[2];
            collision.transform.root.SendMessage("TakeOnBuff", message);

        }
    }
    private void FixedUpdate()
    {
        
        myrb.transform.position = Vector2.MoveTowards(myrb.transform.position,new Vector2(player.position.x,yy), movespeed * Time.deltaTime);
    }
    IEnumerator boom()
    {
        yield return new WaitForSeconds(boomtimes);
        Destroy(gameObject);

    }
}
