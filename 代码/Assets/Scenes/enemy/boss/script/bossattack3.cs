using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossattack3 : MonoBehaviour
{
    Collider2D attackcollider;
    public int attackdamage = 10;//攻击伤害
    public Vector2 attackf = Vector2.zero;//攻击力度
    public float existt = 5;//存在时间
    PlayerHealth playhealth;
    Animator animator;
    public int[] buff = new int[3];
    void Start()
    {
        playhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        StartCoroutine("existtime");
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
    IEnumerator existtime()
    {
        yield return new WaitForSeconds(existt);
        Destroy(gameObject);
    }
}
