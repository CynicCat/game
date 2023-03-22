using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackshort2 : MonoBehaviour
{
    Collider2D attackcollider;
    public int attackdamage = 10;//¹¥»÷ÉËº¦
    public Vector2 attackf = Vector2.zero;//¹¥»÷Á¦¶È
    PlayerHealth playhealth;
    Animator animator;
    public int[] buff = new int[3];
    
    void Start()
    {
        playhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            playhealth.DamagePlayer(attackdamage, Vector2.zero);
            object[] message = new object[3];
            message[0] = buff[0];//fire
            message[1] = buff[1];//ice
            message[2] = buff[2];//posion
            collision.transform.root.SendMessage("TakeOnBuff",message);
            Debug.Log("¹ÖÎï¹¥»÷");
        }
    }
}
