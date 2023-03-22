using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBase : MonoBehaviour
{

    public delegate void FinishState();
    public event FinishState OnStateFinished;
    public float maxTime = 3.0f;
    public float DuringTime { get;  set; }//持续时间
    public int SkillLevel { get; set; }=0;//技能等级
    public float CurrentDurationTimer { get; set; } = 0;//计时临时变量
    public PlayerController player { get; set; }//buff的对象
    public BuffBase Setup(PlayerController player, float Duringtime,int SkillLevel)
    {
        this.player = player;
        this.DuringTime = Duringtime;
        this.SkillLevel = SkillLevel;
        return this;
    }
    public  void Update()
    {
        CurrentDurationTimer += Time.deltaTime;
        if(CurrentDurationTimer>=DuringTime)
        {
            OnStateFinished?.Invoke();
        }
    }
    public void AddDuringTime(float addtime)
    {
        DuringTime+=addtime;
        DuringTime = Mathf.Min(DuringTime, maxTime);
    }

    public virtual void Launch()
    {

    }
   
}
