using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillStatusController : MonoBehaviour
{
    private bool[] SkillIsUnlocked = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    //private bool[] SkillIsUnlocked = { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendSkillStatus(int SkillNumber)
    {
        if (SkillNumber >= 1 && SkillNumber <= 12)
        {
            if (SkillIsUnlocked[SkillNumber - 1] == false)
            {
                this.SendMessage("GetSkillStatus", -SkillNumber);
            }
            else
            {
                this.SendMessage("GetSkillStatus", SkillNumber);
            }
        }

        if (SkillNumber == 13)
        {
            if (SkillIsUnlocked[9 - 1] == true && SkillIsUnlocked[11 - 1] == true)
            {
                if (SkillIsUnlocked[SkillNumber - 1] == false)
                {
                    this.SendMessage("GetSkillStatus", -SkillNumber);
                }
                else
                {
                    this.SendMessage("GetSkillStatus", SkillNumber);
                }
            }
            else
            {
                this.SendMessage("GetSkillStatus", SkillNumber - SkillNumber);
            }
        }

        if (SkillNumber == 14)
        {
            if (SkillIsUnlocked[7 - 1] == true && SkillIsUnlocked[11 - 1] == true)
            {
                if (SkillIsUnlocked[SkillNumber - 1] == false)
                {
                    this.SendMessage("GetSkillStatus", -SkillNumber);
                }
                else
                {
                    this.SendMessage("GetSkillStatus", SkillNumber);
                }
            }
            else
            {
                this.SendMessage("GetSkillStatus", SkillNumber - SkillNumber);
            }
        }

        if (SkillNumber == 15)
        {
            if (SkillIsUnlocked[7 - 1] == true && SkillIsUnlocked[9 - 1] == true)
            {
                if (SkillIsUnlocked[SkillNumber - 1] == false)
                {
                    this.SendMessage("GetSkillStatus", -SkillNumber);
                }
                else
                {
                    this.SendMessage("GetSkillStatus", SkillNumber);
                }
            }
            else
            {
                this.SendMessage("GetSkillStatus", SkillNumber - SkillNumber);
            }
        }
    }

    public void StatusGetSkillUnlock(int UnlockNumber)
    {
        SkillIsUnlocked[UnlockNumber - 1] = true;
    }
}
