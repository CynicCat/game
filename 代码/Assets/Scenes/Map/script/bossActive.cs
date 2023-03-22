using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossActive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int message = 1;
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            //collision.SendMessage("Active", message);
            Debug.Log("boss is Active");
        }
    }
}

