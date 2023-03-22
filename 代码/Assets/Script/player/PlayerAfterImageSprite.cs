using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImageSprite : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float activeTime = 0.1f;//ͼ����Դ��ڵ�ʱ��
    private float timeActivated;//ͼ�񱻼����ʱ��
    private float alpha;//͸����
    /// </summary>
    [SerializeField]
    private float alphaSet=0.8f;//��ʼ��͸����
    private float alphaMultiplier = 0.85f;//ÿ��͸���ȱ仯0.85



    private Transform player;
    private SpriteRenderer SR;
    private SpriteRenderer playerSR;//������Ⱦ��

    private Color color;


    private void OnEnable()
    {
        SR=GetComponent<SpriteRenderer>();//�õ�Ԥ���徫����Ⱦ��
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSR = player.GetComponent<SpriteRenderer>();//�õ�Player�ľ�����Ⱦ��

        alpha = alphaSet;
        SR.sprite = playerSR.sprite;//����ͼ��
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
            PlayerAfterImagePool.Instance.AddToPool(gameObject);//��ͼƬ���뵽���������
        }

    }
}
