using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    
    
    public float runSpeed;//�ƶ��ٶ�
    public float jumpSpeed;//��Ծ�ٶ�
    public float fallMultiplier = 2.5f;//�½��ٶ�
    public float lowJumpMultiplier = 2f;//�����ٶ�
    public float moveDir;//�ƶ�����
    public int amountOfJump;//����Ծ����
    private int amountOfJumpLeft;//ʣ����Ծ����
    private int facingDir=1;//����

    public Transform GroundCheck;//������
    public Transform WallCheck;//ǽ����
    public float GroundCheckRadius;//���뾶��С
    public float WallCheckDistance;//������

    private bool isTouchingWall;//�Ƿ������Ӵ�
    public LayerMask whatisGround;//����ͼ���ɰ�

    private bool isGrounded;//�ж������Ƿ��ڵ���
    // Dash
    private bool isDashing;//�ж��Ƿ��ڳ��
    public float DashTime;//��̵���ʱ��
    public float DashSpeed;//����ٶ�
    public float DistanceBetweenImage;//����� ��Ӱ֮��ľ���
    public float DashCoolDown;//��ȴʱ��

    private float DashTimeLeft;//ʣ��ĳ��ʱ��
    private float LastImageXpos;//���һ����Ӱ��Xλ��
    private float LastDash=-100;//����̵�ʱ��
    public float HealColdDown = 3.0f;//�����ܵ���ȴ
    private float lastHealTime = -100;//�����������Ч��ʱ��
    [SerializeField]
    private Transform BuffBarStaus;//״̬��
    private int amountOfBuffOnPlayer=0;



    private Slider Hp;
    private Rigidbody2D myRigidbody;
    private Animator myAnim;

    public bool canflip;//�Ƿ���Է�ת
    public bool canMove;//�Ƿ�����ƶ�
    public bool enDash;
    private bool canDash;//�Ƿ���Գ��
    private bool canJump;//����Ƿ������Ծ
                         // Start is called before the first frame update

    public GameObject DoubleJump;
    public PlayerCombatContorller PCC;//ս���ű�
    public PlayerHealth PH;//Ѫ��
    public PlayerSkill PS;//���＼��

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
    private void CheckSkill()//��⼼��
    {
        if(PS.Fire>0)//��
        {
            PCC.SkillDegree[0] = PS.Fire;
        }
        if(PS.Ice>0)//��
        {
            PCC.SkillDegree[1]=PS.Ice;
        }
        if(PS.Poison>0)//��
        {
            PCC.SkillDegree[2] = PS.Poison;
        }
        if(PS.Explode>0)//��ը
        {
            PCC.SkillDegree[3]=PS.Explode;
        }
    }
   
    private void CheckInput()//�������
    {
        if (Input.GetButtonDown("Jump"))//������Ծ�� 
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

        //����
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
    private void CheckFacingDir()//����
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
    private void CheckSurroundings()//�����Χ
    {

        //r1 = Physics2D.Raycast(GroundCheck.position, transform.up, GroundCheckRadius,whatisGround);
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, whatisGround);
        isTouchingWall = Physics2D.Raycast(WallCheck.position, transform.right, WallCheckDistance,whatisGround);//ǽ����
    }
    private void CheckIfCanJump()//����Ƿ������Ծ
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
    private void Flip()//��ת����
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
        if (myRigidbody.velocity.y < 0&&!isGrounded)//������y���ϵ��ٶ�
        {
            myRigidbody.gravityScale = fallMultiplier;//gravityScale������������
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
    private void run()//�ƶ�
    {
        if (canMove)
        {
            Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
            myRigidbody.velocity = playerVel;
            bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
            myAnim.SetBool("run", playerHasXAxisSpeed);
        }
    }

    private void jump()//��Ծ
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
    void SwitchAnimation()//�л�����
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
    //�����ܷ�ת�Ľ�ֹ������
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
