using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockofenergy : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Player")&&collision.GetType().ToString()== "UnityEngine.CapsuleCollider2D")
        {
            BEUi.CurrentBENum += 1;
            Destroy(gameObject);
        }
    }
}
