using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImageSprite : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float activeTime = 0.1f;//图像可以存在的时间
    private float timeActivated;//图像被激活的时间
    private float alpha;//透明度
    /// </summary>
    [SerializeField]
    private float alphaSet=0.8f;//初始的透明度
    private float alphaMultiplier = 0.85f;//每次透明度变化0.85



    private Transform player;
    private SpriteRenderer SR;
    private SpriteRenderer playerSR;//精灵渲染器

    private Color color;


    private void OnEnable()
    {
        SR=GetComponent<SpriteRenderer>();//得到预制体精灵渲染器
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSR = player.GetComponent<SpriteRenderer>();//得到Player的精灵渲染器

        alpha = alphaSet;
        SR.sprite = playerSR.sprite;//传递图像
        transform.position = player.position;
        transform.rotation = player.rotation;
        timeActivated = Time.time;



    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alpha *= alphaMultiplier;
        color = new Color(1f, 1f, 1f, alpha);
        SR.color = color;

        if(Time.time>=(activeTime+timeActivated))
        {
            PlayerAfterImagePool.Instance.AddToPool(gameObject);//将图片加入到对象池里面
        }

    }
}
