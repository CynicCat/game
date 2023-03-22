using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    
    
    public float runSpeed;//移动速度
    public float jumpSpeed;//跳跃速度
    public float fallMultiplier = 2.5f;//下降速度
    public float lowJumpMultiplier = 2f;//上升速度
    public float moveDir;//移动方向
    public int amountOfJump;//总跳跃次数
    private int amountOfJumpLeft;//剩余跳跃次数
    private int facingDir=1;//朝向

    public Transform GroundCheck;//地面检测
    public Transform WallCheck;//墙面检测
    public float GroundCheckRadius;//检测半径大小
    public float WallCheckDistance;//检测距离

    private bool isTouchingWall;//是否与地面接触
    public LayerMask whatisGround;//地面图层蒙板

    private bool isGrounded;//判断人物是否处于地面
    // Dash
    private bool isDashing;//判断是否在冲刺
    public float DashTime;//冲刺的总时间
    public float DashSpeed;//冲刺速度
    public float DistanceBetweenImage;//冲刺中 残影之间的距离
    public float DashCoolDown;//冷却时间

    private float DashTimeLeft;//剩余的冲刺时间
    private float LastImageXpos;//最后一个残影的X位置
    private float LastDash=-100;//最后冲刺的时间
    public float HealColdDown = 3.0f;//愈技能的冷却
    private float lastHealTime = -100;//最后愈技能生效的时间
    [SerializeField]
    private Transform BuffBarStaus;//状态栏
    private int amountOfBuffOnPlayer=0;



    private Slider Hp;
    private Rigidbody2D myRigidbody;
    private Animator myAnim;

    public bool canflip;//是否可以翻转
    public bool canMove;//是否可以移动
    public bool enDash;
    private bool canDash;//是否可以冲刺
    private bool canJump;//检测是否可以跳跃
                         // Start is called before the first frame update

    public GameObject DoubleJump;
    public PlayerCombatContorller PCC;//战斗脚本
    public PlayerHealth PH;//血条
    public PlayerSkill PS;//人物技能

    void Start()
    {
        amountOfJumpLeft = amountOfJump;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        
        //Hp = GameObject.Find("Canvas/HealthBar").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (canflip)
            Flip();
        CheckInput();
        CheckSurroundings();
        CheckFacingDir();
        CheckIfCanJump();
        CheckSkill();
        //attack();
    }
    private void CheckSkill()//检测技能
    {
        if(PS.Fire>0)//火
        {
            PCC.SkillDegree[0] = PS.Fire;
        }
        if(PS.Ice>0)//冰
        {
            PCC.SkillDegree[1]=PS.Ice;
        }
        if(PS.Poison>0)//毒
        {
            PCC.SkillDegree[2] = PS.Poison;
        }
        if(PS.Explode>0)//爆炸
        {
            PCC.SkillDegree[3]=PS.Explode;
        }
    }
   
    private void CheckInput()//检测输入
    {
        if (Input.GetButtonDown("Jump"))//按下跳跃键 
        {
            jump();
        }
        moveDir = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Dash")&&enDash)
        {
            Debug.Log(enDash);
            if(Time.time>=(LastDash+DashCoolDown))
            {
                AttemptToDash();
            }
        }

        //测试
        if (Input.GetKeyDown("1"))
        {
            if(!GetComponent<PlayFireBuff>())
            {
                gameObject.AddComponent<PlayFireBuff>().Setup(GetComponent<PlayerController>(), 3, 0).Launch();
                gameObject.AddComponent<PlayIceBuff>().Setup(GetComponent<PlayerController>(), 3, 0).Launch();
                gameObject.AddComponent<PlayPosionBuff>().Setup(GetComponent<PlayerController>(), 3, 0).Launch();
            }
        }
    }
    private void CheckFacingDir()//方向
    {
        if (moveDir > 0)
        { 
            facingDir = 1; 
        }
        else if (moveDir<0)
        {
            facingDir = -1;
        }
    }
    private void FixedUpdate()
    {
        GriavityFixed();
        SwitchAnimation();
        CheckDash();
        run();
    }
    private void CheckSurroundings()//检测周围
    {

        //r1 = Physics2D.Raycast(GroundCheck.position, transform.up, GroundCheckRadius,whatisGround);
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, whatisGround);
        isTouchingWall = Physics2D.Raycast(WallCheck.position, transform.right, WallCheckDistance,whatisGround);//墙面检测
    }
    private void CheckIfCanJump()//检测是否可以跳跃
    {
        if(isGrounded&&myRigidbody.velocity.y<=0)
        {
            amountOfJumpLeft=amountOfJump;
        }

        if (amountOfJumpLeft <= 0)
        {
            canJump = false;

        }
        else
        { 
            canJump = true;
        }

    }
    public void TakeOnBuff(object[] message)
    { 
        if ((int)message[0]>0&&PS.FireImmunity==0)
        {
            if(!GetComponent<PlayFireBuff>())
                gameObject.AddComponent<PlayFireBuff>().Setup(GetComponent<PlayerController>(), 3, PS.Fire).Launch();
        }
        if((int) message[1]>0&&PS.IceImmunity==0)
        {
            if(!GetComponent<PlayIceBuff>())
                gameObject.AddComponent<PlayIceBuff>().Setup(GetComponent<PlayerController>(), 3, PS.Ice).Launch();
        }
        if ((int) message[2]>0&&PS.PoisonImmunity==0)
        {
            if(!GetComponent<PlayPosionBuff>())
                gameObject.AddComponent<PlayPosionBuff>().Setup(GetComponent<PlayerController>(), 3, PS.Poison).Launch();


        }
    }
    public void SwitchToBuff(int id)
    {
        Debug.Log("yes");
        if (id == 1)
        {
            addAmountOfJump();
        }
        else if (id == 2)
        {
            enDash = true;
        }
        else if (id == 3)
        {
            if (PCC.BulletEnabled == false)
                PCC.BulletEnabled = true;
            else
            {
                GameController.instance.BulletDamage += 1;
            }

        }
        else if (id == 4)
        {
            PH.HealthBar.maxValue += 20;
            PH.health += 20;
        }
        else if (id == 5)
        {
            PCC.attackDamage += 1;
        }
        else if (id == 6)
        {
            if (PCC.BulletEnabled == false)
                PCC.BulletEnabled = true;
            else
            {
                GameController.instance.BulletDamage += 1;
            }
        }
        else if (id == 7) PS.Fire++;
        else if (id == 8) PS.FireImmunity++;
        else if (id == 9) PS.Ice++;
        else if (id == 10) PS.IceImmunity++;
        else if (id == 11) PS.Poison++;
        else if (id == 12) PS.PoisonImmunity++;
        else if ((id == 13)) PS.Heal++;
        else if (id == 14) PS.Explode++;
        else if(id==15)PS.Tied++;
    }
    private void Flip()//翻转人物
    {
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {
            if (myRigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);

            }
            if (myRigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
    private void GriavityFixed()
    {
        if (myRigidbody.velocity.y < 0&&!isGrounded)//刚体在y轴上的速度
        {
            myRigidbody.gravityScale = fallMultiplier;//gravityScale是重力的速率
        }
        else if (myRigidbody.velocity.y > 0)
        {
            myRigidbody.gravityScale = lowJumpMultiplier;
        }
        else
        {
            myRigidbody.gravityScale = 1f;
        }
    }
    private void run()//移动
    {
        if (canMove)
        {
            Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
            myRigidbody.velocity = playerVel;
            bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
            myAnim.SetBool("run", playerHasXAxisSpeed);
        }
    }

    private void jump()//跳跃
    {
        if (canJump&&!myAnim.GetBool("isAttacking"))
        {
            myAnim.SetBool("jump", true);
            if (amountOfJump > 1 && amountOfJump - amountOfJumpLeft > 0)
            { 
                Instantiate(DoubleJump, this.transform);
                AudioController.instance.PlayAudio(4,transform); 
            }
            //else AudioController.instance.PlayAudio(3,transform);
            myRigidbody.velocity =new Vector2(myRigidbody.velocity.x,jumpSpeed);
            amountOfJumpLeft--;

        }
      
    }
    private void AttemptToDash()
    {
        isDashing = true;
        DashTimeLeft = DashTime;
        LastDash = Time.time;
        PlayerAfterImagePool.Instance.GetFromPool();
        LastImageXpos = transform.position.x;
        AudioController.instance.PlayAudio(7,transform);
    }
    private void CheckDash()
    {
        if(isDashing)
        {
            canMove = false;
            canflip = false;
            canDash = false;
            myRigidbody.velocity = new Vector2(DashSpeed * facingDir, myRigidbody.velocity.y);
            DashTimeLeft -= Time.deltaTime;
            Debug.Log(myRigidbody.velocity);

            if(Mathf.Abs(transform.position.x-LastImageXpos)>DistanceBetweenImage)
            {
                PlayerAfterImagePool.Instance.GetFromPool();
                LastImageXpos=transform.position.x;
            }
        }
        if(DashTimeLeft<=0||isTouchingWall)
        {
            isDashing=false;
            canMove = true;
            canflip = true;
            canDash = true;
        }
    }
    void SwitchAnimation()//切换动画
    {
        myAnim.SetBool("origin", false);
        if (myAnim.GetBool("jump"))
        {
            if (myRigidbody.velocity.y <= 0&&myAnim.GetBool("isAttacking")==false)
            {
                Debug.Log("changetofall");
                myAnim.SetBool("jump", false);
                myAnim.SetBool("fall", true);
            }
           
        }
        if(isGrounded&&myRigidbody.velocity.y<=0)
        {
            myAnim.SetBool("jump", false);
            myAnim.SetBool("fall", false);
            myAnim.SetBool("origin", true);
        }
    }
    //对于能否翻转的禁止与启用
    public void DisableFlip()
    {
        canflip = false;
    }
    public void EnableFlip()
    {
        canflip = true;
    }
    private void addAmountOfJump()
    {
        amountOfJump++;
    }
    private void OnDrawGizmos()
    {

        //Gizmos.DrawLine(GroundCheck.position, new Vector3(GroundCheck.position.x, GroundCheck.position.y+GroundCheckRadius,GroundCheck.position.z));
        Gizmos.DrawWireSphere(GroundCheck.position, GroundCheckRadius);
        //Gizmos.DrawWireCube(GroundCheck.position, new Vector3(8, 1, 1));

        Gizmos.DrawLine(WallCheck.position, new Vector3(WallCheck.position.x + transform.right.x*WallCheckDistance, WallCheck.position.y, WallCheck.position.z));

    }


}
