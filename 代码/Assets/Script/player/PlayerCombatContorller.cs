using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatContorller : MonoBehaviour
{
    public GameObject BulletPoint;
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private bool combatEnabled;//检测是否可以战斗
    public bool BulletEnabled;
    [SerializeField]
    private float inputTimer, inputBulletTimer;//输入计时器 用于攻击间隔
    [SerializeField]
    private Transform attackHitBoxPos;
    [SerializeField]
    private LayerMask whatisDamageable;
    private bool gotInput,gotBulletInput;//是否获取攻击输入

    private bool isAttacking, isFirstAttack,isShooting;
    private float lastInputTime=Mathf.NegativeInfinity,lastBulletInputTime=Mathf.NegativeInfinity;//记录最后一次攻击输入的时间,用最小值初始化
    [SerializeField]
    private float attackRadius;
    public float attackDamage;
    private Animator anim;
    public int[] SkillDegree=new int[4];//技能等级
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack",enabled);
    }
    void Update()
    {
        CheckCombatInput();
        CheckAttack();
        CheckBullet();
    }
    private void CheckCombatInput()//检测任何玩家关于战斗的输入
    {
        if (Input.GetButtonDown("Attack"))
        {
            if(combatEnabled)
            {
                //战斗模板
                gotInput = true;
                lastInputTime = Time.time;

            }
        }
        if(Input.GetButtonDown("Bullet"))
        {
            if (BulletEnabled)
            {
                //战斗模板
                gotBulletInput = true;

            }
        }

    }
    private void CheckBullet()
    {
        if (Time.time <= lastBulletInputTime + inputBulletTimer)
        {
            gotBulletInput = false;
        }
        if (gotBulletInput)
        {
            //if (!isShooting)
            {
                Debug.Log("shoot");
                AudioController.instance.PlayAudio(0,transform);
                Instantiate(BulletPrefab, BulletPoint.transform.position, BulletPoint.transform.rotation);
                gotBulletInput = false;
                lastBulletInputTime = Time.time;

            }
        }
       
    }
    private void CheckAttack()
    {
        if(gotInput)
        {
            if(!isAttacking)
            {
                AudioController.instance.PlayAudio(1, transform);
                isFirstAttack = !isFirstAttack;
                gotInput = false;
                isAttacking = true;
                if (isFirstAttack)
                {
                    anim.SetBool("attack1", true);
                }
                else
                { 
                    anim.SetBool("attack2", true);
                }
                anim.SetBool("firstAttack",isFirstAttack);
                anim.SetBool("isAttacking",isAttacking);

            }
        }
        if(Time.time>=lastInputTime+inputTimer)
        {
            gotInput=false;
        }
    }
    private void CheckAttackHitBox()//检测可以攻击的对象
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackHitBoxPos.position,attackRadius,whatisDamageable);
        object[] message = new object[7];
        message[0] = attackDamage;
        message[1] = attackHitBoxPos.position.x;
        message[2]=attackHitBoxPos.position.y;
        message[3] = SkillDegree[0];//火
        message[4] = SkillDegree[1];//冰
        message[5] = SkillDegree[2];//毒
        message[6] = SkillDegree[3];//爆
        foreach(Collider2D collider in detectedObjects)
        {
            collider.transform.root.SendMessage("Damage",message);//发送信息
        }
    }

    private void FinishAttack()
    {
        isAttacking = false;
        anim.SetBool("isAttacking",isAttacking);
        if (anim.GetBool("attack1"))
        {
            anim.SetBool("attack1", false);
        }
        else if(anim.GetBool("attack2"))
            anim.SetBool("attack2", false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackHitBoxPos.position,attackRadius);
    }
}
