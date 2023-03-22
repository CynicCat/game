 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float healthMax;
    public int Blinks;//…¡À∏¥Œ ˝
    public float time;//…¡À∏ ±º‰
    public float dieTime;
    public float hitBoxCd;
    public UnityEvent<int, Vector2> damageableHit;
    public Slider HealthBar;
    private Renderer myRender;
    private Animator anim;
    private PolygonCollider2D polygonCollider2D;
    public GameObject HealDialog;
    bool DialogTrue = false;
    public float fixedDamage=1.0f;
    public bool canrevival=false;
    // Start is called before the first frame update
    void Start()
    {
        myRender = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        HealthBar = GameObject.Find("Canvas/HealthBar").GetComponent<Slider>();
        HealthBar.maxValue = healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        recover();
        HealthBar.value = health;


    }
    public void DamagePlayer(int damage,Vector2 attackf)
    {
        health -= damage;
        HealthBar.value -= damage;
        AudioController.instance.PlayAudio(5, transform);//Ã€Õ¥1
        BlinkPlayer(Blinks, time);
        damageableHit?.Invoke(damage, attackf);
        if(health<=0&&canrevival==true)
        {
            canrevival = false;
            health = 0.5f * HealthBar.maxValue;
        }
        if (health <= 0)
        {
            anim.SetTrigger("die");
            Invoke("killPlayer", dieTime);
            
        }
        polygonCollider2D.enabled = false;//≥÷–¯ºÏ≤‚µÿ¥Ã ‹…À
        StartCoroutine(ShowPlayerHitBox());
    }


    void killPlayer()
    {
        Destroy(gameObject);
    }

    void BlinkPlayer(int numBlinks,float seconds)// ‹…À…¡À∏
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
        
    }

    IEnumerator ShowPlayerHitBox()// ‹…ÀºÏ≤‚
    {
        yield return new WaitForSeconds(hitBoxCd);
        polygonCollider2D.enabled = true;
    }

    IEnumerator DoBlinks(int numBlinks,float seconds)// ‹…À…¡À∏
    {
        for(int i = 0; i < numBlinks*2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }

    private void recover()
    {

        if (Input.GetButtonDown("Recover"))
        {
            DialogTrue = !DialogTrue;
        }
        if (DialogTrue)
        {
            HealDialog.SetActive(true);
        }
        else
        {
            HealDialog.SetActive(false);
        }

    }
    public void heal()
    {
        health = healthMax;
        HealthBar.value = health;
    }

    public void Noshow()
    {
        DialogTrue=false;
    }
}
