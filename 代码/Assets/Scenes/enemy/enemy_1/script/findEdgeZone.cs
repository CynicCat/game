using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findEdgeZone : MonoBehaviour
{
    public List<Collider2D> zoneColider = new List<Collider2D>();
    Collider2D col;
    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision) //碰撞物体进入
    {
        zoneColider.Add(collision);

    }

    private void OnTriggerExit2D(Collider2D collision)//碰撞物体退出
    {
        zoneColider.Remove(collision);
    }
}
