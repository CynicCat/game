using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBroken : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D bx2d;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bx2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")&&collision.GetType().ToString()== "UnityEngine.BoxCollider2D")
        {
            anim.SetTrigger("broken");
        }
    }
    
    void DisabledBoxCollider2D()
    {
        bx2d.enabled = false;
    }

    void DestroyPlatformBroken()
    {
        Destroy(gameObject);
    }
}
