using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float BulletSpeed = 35.0f;
    [SerializeField]
    private float activeTime = 1.0f;
    private float timeActived;
    private bool isTouching;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * BulletSpeed;
        Destroy(gameObject,3);
        timeActived = Time.time;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        object[] message = new object[7];
        message[0] = GameController.instance.BulletDamage;
        message[1] = transform.position.x;
        message[2] = transform.position.y;
        message[3] = 0;
        message[4] = 0;
        message[5] =0;
        message[6] = 0;
        if (collision.CompareTag("enemy")&&collision.GetType().ToString()== "UnityEngine.BoxCollider2D")
        {
            collision.transform.root.SendMessage("Damage", message);//发送信息
            Debug.Log("Target was Hit!");
            Destroy(gameObject);
        }
    }
    private void BulletRun()
    {
        if(Time.time>=(activeTime+timeActived))
        {
            Destroy(this.gameObject);
            Debug.Log("消失");
        }
    }
}
