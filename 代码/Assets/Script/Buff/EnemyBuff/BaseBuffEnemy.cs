using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuffEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void FinishState();
    public event FinishState OnStateFinished;
    public float DuringTime { get; set; }//����ʱ��
    public int SkillLevel { get; set; } = 0;//���ܵȼ�
    public float CurrentDurationTimer { get; set; } = 0;//��ʱ��ʱ����
    public enemy_health enemy_Health { get; set; }//buff�Ķ���
    public enemy_walk enemy_Walk { get; set; }
    public BaseBuffEnemy Setup(enemy_health enemy_health, enemy_walk enemy_Walk, float Duringtime, int SkillLevel)
    {
        this.enemy_Health = enemy_health;
        this.enemy_Walk = enemy_Walk;
        this.DuringTime = Duringtime;
        this.SkillLevel = SkillLevel;
        return this;
    }
    public  void Update()
    {
        CurrentDurationTimer += Time.deltaTime;
        if (CurrentDurationTimer >= DuringTime)
        {
            OnStateFinished?.Invoke();
        }
    }

    public virtual void Launch()
    {

    }
}
