using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeHide : MonoBehaviour
{
    private Animator anim;
    public float time;
    public GameObject attackBox;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            StartCoroutine(SpikeAttack());
        }
    }

    IEnumerator SpikeAttack()
    {
        yield return new WaitForSeconds(time);
        anim.SetTrigger("Attack");
        Instantiate(attackBox, transform.position, Quaternion.identity);
    }
}
