using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackBox : MonoBehaviour
{
    public int damage;
    public float destroyTime;
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            playerHealth.DamagePlayer(damage, Vector2.zero);
        }
    }
}
