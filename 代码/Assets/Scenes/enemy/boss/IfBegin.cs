using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfBegin : MonoBehaviour
{
    public List<Collider2D> zoneColider = new List<Collider2D>();
    Collider2D col;
    boss_s BOSS;
    private void Awake()
    {
        col = GetComponent<Collider2D>();
        BOSS = GameObject.FindGameObjectWithTag("enemy").GetComponent<boss_s>();
    }
    protected void OnTriggerEnter2D(Collider2D collision) //碰撞物体进入
    {
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.PolygonCollider2D")
            BOSS.IfBeginFight = true;

    }
}
