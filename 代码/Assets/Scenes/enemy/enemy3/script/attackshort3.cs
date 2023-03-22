using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackshort3 : MonoBehaviour
{
    Collider2D attackcollider;
    public int attackdamage = 10;//�����˺�
    public Vector2 attackf = Vector2.zero;//��������
    PlayerHealth playhealth;
    Animator animator;
    void Start()
    {
        playhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            playhealth.DamagePlayer(attackdamage, Vector2.zero);
            Debug.Log("���﹥��");
        }
    }
}
