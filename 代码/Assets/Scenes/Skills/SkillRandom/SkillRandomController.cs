using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRandomController : MonoBehaviour
{
    static int[] CanUnlockInitially = {1,2,3,4,5,6,7,8,9,10,11,12};
    List<int> CanUnlock = new List<int>(CanUnlockInitially);
    private ArrayList random = new ArrayList();

    string[] SkillRandomFieldNumber = { "SkillRandomField_0", "SkillRandomField_1", "SkillRandomField_2", "SkillRandomField_3", "SkillRandomField_4", "SkillRandomField_5" , "SkillRandomField_6" , "SkillRandomField_7" , "SkillRandomField_8" , "SkillRandomField_9" , "SkillRandomField_10" , "SkillRandomField_11" };
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SkillRandom()
    {
        random.Clear();
        while(random.Count < 3)
        {
            System.Random r = new System.Random();
            int i = r.Next(1, CanUnlock.Count + 1);
            if (!random.Contains(CanUnlock[i - 1]))
            {
                random.Add(CanUnlock[i - 1]);
            }
        }
    }

    public void Refresh(int FieldNumber)
    {
        SkillRandom();
        GameObject.Find(SkillRandomFieldNumber[FieldNumber-1]).SendMessage("ReceiveRandom", random);
    }

    public void RandomGetSkillUnlock(int UnlockNumber)
    {
        CanUnlock.Remove(UnlockNumber);
        if (UnlockNumber == 7)
        {
            if (CanUnlock.Contains(9) == false)
            {
                CanUnlock.Add(15);
            }
            if (CanUnlock.Contains(11) == false)
            {
                CanUnlock.Add(14);
            }
        }
        if(UnlockNumber == 9)
        {
            if (CanUnlock.Contains(7) == false)
            {
                CanUnlock.Add(15);
            }
            if (CanUnlock.Contains(11) == false)
            {
                CanUnlock.Add(13);
            }
        }
        if (UnlockNumber == 11)
        {
            if (CanUnlock.Contains(7) == false)
            {
                CanUnlock.Add(14);
            }
            if(CanUnlock.Contains(9)==false)
            {
                CanUnlock.Add(13);
            }
        }
    }
}
