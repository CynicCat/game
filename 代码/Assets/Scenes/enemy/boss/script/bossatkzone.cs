using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossatkzone : MonoBehaviour
{
    public List<Collider2D> zoneColider = new List<Collider2D>();
    Collider2D col;
    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }
    protected void OnTriggerEnter2D(Collider2D collision) //��ײ�������
    {
        if (collision.CompareTag("Player"))
            zoneColider.Add(collision);

    }

    protected void OnTriggerExit2D(Collider2D collision)//��ײ�����˳�
    {
        if (collision.CompareTag("Player"))
            zoneColider.Remove(collision);
    }

}
