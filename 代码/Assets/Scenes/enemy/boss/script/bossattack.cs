using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossattack : MonoBehaviour
{
    Collider2D attackcollider;
    public float ratespeed = 3;
    PlayerController playerController;
    Animator animator;
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            playerController.runSpeed -=ratespeed;
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            playerController.runSpeed += ratespeed;
        }
    }
}
