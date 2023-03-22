using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameController instance { get; private set; }//获取和设置字段（属性）的值
    public float BulletDamage=1.0f;
    public int skill_id;
    void Start()
    {
        GameController.instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
