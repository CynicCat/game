using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SkillTreeController : MonoBehaviour
{
    private bool IsShow;
    public int SkillStatus;
    public GameObject SkillTree;
    
    public GameObject SkillName;
    public GameObject SkillBackground;
    public GameObject SkillDescription;
    public GameObject LevelUpEffect;
    public GameObject LevelUp;
    public GameObject SkillTips;
    public GameObject EnergyCost;

    public Image Image;
    public Texture2D Texture;
    public Sprite Sprite;

    string[] skillname_TMP = { "二段跳", "冲刺", "重生", "生命值增加", "近战伤害提高", "远程伤害提高", "炎之心", "浴炎不灼", "冰魄", "历冰不冻", "毒息", "百毒不侵", "回春", "审判", "圣甲" };
    string[] skillbackground_TMP = { "繁荣纪元，人联境内禁止非军方机甲飞行，由于复杂环境的工作需求，冠军科技设计了短时展开的上升矩阵替代飞行，并在客户强烈要求下将矩阵形象排列为光翼外形。", "人联远征军征战环科摩多星带期间，出于小行星地表作战需求，向冠军科技公司定制的作战方程式，用于满足重火力失效情况下的短距离作战需求，可以实现小范围机动作战。","远征时期，受补给距离限制，军方作战装甲部队损毁率过高。由生产部牵头联合学院教授一同研究出来的机甲重启技术，通过未损毁部件的自我重组实现机甲损毁后的二次启动。大大降低了远征军机甲的损毁率。","星际殖民时期，远征军在科摩多星系发现了高纯度富集能源结晶矿。过高纯度的能源结晶受外界扰动易产生晶爆。相较于复杂昂贵的静默采矿技术，生产部选择了更为经济实惠的装甲增殖技术替代，既然爆炸无法规避，那就让它炸。只要没坏，等于没炸。","繁荣纪元，陆地执法部队标配序列，根据危害程度的判定，逐步提高动力装甲的输出功率。","繁荣纪元，陆地执法部队标配序列，面对防抗执法的暴徒将解除火控限制。根据危害程度的判定，逐步提高火控系统的输出功率。","智械危机发生后，军团针对智械控制的无人机甲部队开发出来的作战系统，对各类装甲具有除显性损毁外的构造瓦解，造成装甲易损状态。由元帅命名为炎之心。", "第二次决战中段，学院部分高层叛变，炎之心项目资料泄露，智械一方同样装配了炎之心作战系统。针对当前状况，研发部紧急制作出来反制程序。通过构件的复解，可以抵抗炎之心对装甲的构造瓦解，由博士命名为浴炎不灼系统。", "智械危机发生后，军团针对智械控制的无人机甲部队开发出来的作战系统，对各类装甲除构造层面损毁外，附着阻碍机甲运行的冷冻液，限制装甲移动。由元帅命名为冰魄。","第二次决战中段，学院部分高层叛变，冰魄项目资料泄露，智械一方同样装配了冰魄作战系统。针对当前状况，研发部紧急制作出来反制程序。通过增设内循环动力体系，可以避开冰魄对装甲的限制，由博士命名为历冰不冻系统。","智械危机发生后，军团针对智械控制的无人机甲部队开发出来的作战系统，对各类装甲具有除即时损毁外的持续伤害。由元帅命名为毒息。","第二次决战中段，学院部分高层叛变，毒息项目资料泄露，智械一方同样装配了毒息作战系统。针对当前状况，研发部紧急制作出来反制程序。通过外装甲的重构，可以抵抗毒息对装甲的持续腐蚀，由博士命名为百毒不侵系统。","研发部在回收科摩多采集的高纯度能源结晶后，发现其除贮藏由丰富的能源外，还具有促使各类物质一定程度复位的特性，可以用于机甲的即时维修。模仿能源结晶的该特效，博士为机甲安装了愈合系统，因其表现形式类似生物体自我愈合，故命名为回春系统。","第三次决战期间，人联部队在对智械作战中陷入颓势。元帅制定了对智械本体的特种作战计划，为保证突击小队的作战能力以及提高行动的成功率，由博士研发的大威力武器。元帅将其命名为“审判”。","第三次决战期间，人联部队在对智械作战中陷入颓势。元帅制定了对智械本体的特种作战计划，为保证突击小队的安全以及提高行动的成功率，由博士研发的新型护甲结构，可以分担机甲受到的伤害。由元帅命名为“圣甲”。" };
    string[] skilldescription = { "解锁空中二段跳跃的能力", "解锁向前进方向冲刺一段距离的能力", "使角色在被击败后不直接死亡而是半血原地复活继续游戏，一次游戏只能使用一次", "提高角色血量的上限100", "提高角色近战伤害10点", "解锁远程攻击，攻击力为50点", "为角色近战攻击附着火属性伤害，为敌人附加灼伤状态，此状态下次受到攻击，伤害为150%", "为角色免疫一切火属性负面效果", "为角色近战攻击附着冰属性伤害，为敌人附加冰冻状态，此状态下移动能力受到限制，降低移动速度10%", "为角色免疫一切冰属性负面效果", "为角色近战攻击附着毒属性伤害，为敌人附加中毒状态，此状态下将每秒受到20点腐蚀伤害", "为角色免疫一切毒属性负面效果", "解锁冰+毒后才允许解锁，缓慢恢复角色生命值,每秒回复5%", "解锁火+毒后才允许解锁，瞬间对周围单位造成5倍近战伤害", "解锁火+冰后才允许解锁，怪物对角色造成的伤害降低为原来的50%" };
    string[] levelupeffect = { "该技能无法升级！", "该技能无法升级！", "该技能无法升级！","每次升级提高角色血量上限100点","每次升级提高角色近战伤害10点","每次升级提高角色远程伤害5点","每次升级增强灼伤效果，伤害提高10%", "该技能无法升级！","每次升级增强冰冻效果，移动速度降低幅度增加10%", "该技能无法升级！","每次升级增强腐蚀效果，腐蚀伤害提高10点", "该技能无法升级！", "该技能无法升级！", "该技能无法升级！", "该技能无法升级！" };
    string[] skillname = { "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "Skill7", "Skill8", "Skill9", "Skill10", "Skill11", "Skill12", "Skill13", "Skill14", "Skill15" };
    string[] skillname_unlock = { "Skill1_lock", "Skill2_lock", "Skill3_lock", "Skill4_lock", "Skill5_lock", "Skill6_lock", "Skill7_lock", "Skill8_lock", "Skill9_lock", "Skill10_lock", "Skill11_lock", "Skill12_lock", "Skill13_lock", "Skill14_lock", "Skill15_lock" };
    string[] CanLevelUpPath = { "Skill1/Text (TMP)", "Skill2/Text (TMP)", "Skill3/Text (TMP)", "Skill4/Text (TMP)", "Skill5/Text (TMP)", "Skill6/Text (TMP)", "Skill7/Text (TMP)", "Skill8/Text (TMP)", "Skill9/Text (TMP)", "Skill10/Text (TMP)", "Skill11/Text (TMP)", "Skill12/Text (TMP)", "Skill13/Text (TMP)", "Skill14/Text (TMP)" , "Skill15/Text (TMP)" };
    int[] SkillLevel = { 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0 };

    private bool[] SkillIsUnlocked = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    //private bool[] SkillIsUnlocked = { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
    static int[] CanLevelUp = {4,5,6,7,9,11};
    List<int> canlevelup = new List<int>(CanLevelUp);
    // Start is called before the first frame update
    void Start()
    {
        // UI界面组件获取
        SkillName = GameObject.Find("SkillTree/Background/SkillName");
        SkillBackground = GameObject.Find("SkillTree/Background/SkillBackground");
        SkillDescription = GameObject.Find("SkillTree/Background/SkillDescription");
        LevelUpEffect = GameObject.Find("SkillTree/Background/LevelUpEffect");
        LevelUp = GameObject.Find("SkillTree/Background/LevelUp");
        SkillTips = GameObject.Find("SkillTree/Background/SkillTips");
        EnergyCost = GameObject.Find("SkillTree/Background/LevelUp/Energy/EnergyCost");

        // UI界面初始化
        SkillTree = GameObject.Find("SkillTree/Background");
        SkillTree.SetActive(false);
        IsShow = false;
        SkillStatus = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UIDisplay();
    }

    void UIDisplay()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (IsShow == false)
            {
                SkillTree.SetActive(true);
                IsShow = !IsShow;
            }
            else
            {
                SkillTree.SetActive(false);
                IsShow = !IsShow;
            }
        }

        if (IsShow == true)
        {
            UIGenerate(SkillStatus);
            SkillUnlockGenerate();
        }
    }

    void UIGenerate(int Status)
    {
        if (Status == 0)
        {
            SkillName.SetActive(false);
            SkillBackground.SetActive(false);
            SkillDescription.SetActive(false);
            LevelUpEffect.SetActive(false);
            LevelUp.SetActive(false);
            SkillTips.SetActive(false);
        }
        else
        {
            SkillName.SetActive(true);
            SkillName.GetComponent<TMP_Text>().text = skillname_TMP[Math.Abs(Status) - 1];
            SkillBackground.SetActive(true);
            SkillBackground.GetComponent<TMP_Text>().text = "技能背景：" + skillbackground_TMP[Math.Abs(Status) - 1];
            SkillDescription.SetActive(true);
            SkillDescription.GetComponent<TMP_Text>().text = "技能描述：" + skilldescription[Math.Abs(Status) - 1];
            LevelUpEffect.SetActive(true);
            LevelUpEffect.GetComponent<TMP_Text>().text = "升级效果：" + levelupeffect[Math.Abs(Status) - 1];
            if (Status < 0)
            {
                LevelUp.SetActive(false);
                SkillTips.SetActive(true);
                SkillTips.GetComponent<TMP_Text>().text = "请先解锁技能！";
            }
            else
            {
                if (canlevelup.Contains(Math.Abs(Status)))
                {
                    LevelUp.SetActive(true);
                    SkillTips.SetActive(false);
                    if (BEUi.CurrentBENum >= 10)
                    {
                        EnergyCost.GetComponent<TMP_Text>().color = Color.white;
                    }
                    else
                    {
                        EnergyCost.GetComponent<TMP_Text>().color = Color.red;
                    }
                }
                else
                {
                    LevelUp.SetActive(false);
                    SkillTips.SetActive(true);
                    SkillTips.GetComponent<TMP_Text>().text = "当前技能已达满级！";
                }
            }
        }
    }

    void SkillUnlockGenerate()
    {
        for (int i = 1; i<=12;i++)
        {
            if(SkillIsUnlocked[i - 1] == true)
            {
                Image = GameObject.Find(skillname[Math.Abs(i) - 1]).GetComponent<Image>();
                Texture = Resources.Load<Texture2D>(skillname[Math.Abs(i) - 1]);
                Sprite = Sprite.Create(Texture, new Rect(0, 0, Texture.width, Texture.height), new Vector2(0.5f, 0.5f));
                Image.sprite = Sprite;

                if (canlevelup.Contains(i))
                {
                    GameObject.Find(CanLevelUpPath[i - 1]).GetComponent<TMP_Text>().text = Convert.ToString(SkillLevel[i-1]);
                }
            }
        }
        if (SkillIsUnlocked[9 - 1] == true && SkillIsUnlocked[11 - 1] == true)
        {
            if (SkillIsUnlocked[13 - 1] == false)
            {
                Image = GameObject.Find(skillname[13 - 1]).GetComponent<Image>();
                Texture = Resources.Load<Texture2D>(skillname_unlock[13 - 1]);
                Sprite = Sprite.Create(Texture, new Rect(0, 0, Texture.width, Texture.height), new Vector2(0.5f, 0.5f));
                Image.sprite = Sprite;
            }
            else
            {
                Image = GameObject.Find(skillname[13 - 1]).GetComponent<Image>();
                Texture = Resources.Load<Texture2D>(skillname[13 - 1]);
                Sprite = Sprite.Create(Texture, new Rect(0, 0, Texture.width, Texture.height), new Vector2(0.5f, 0.5f));
                Image.sprite = Sprite;
            }
        }
        if (SkillIsUnlocked[7 - 1] == true && SkillIsUnlocked[9 - 1] == true)
        {
            if (SkillIsUnlocked[15 - 1] == false)
            {
                Image = GameObject.Find(skillname[15 - 1]).GetComponent<Image>();
                Texture = Resources.Load<Texture2D>(skillname_unlock[15 - 1]);
                Sprite = Sprite.Create(Texture, new Rect(0, 0, Texture.width, Texture.height), new Vector2(0.5f, 0.5f));
                Image.sprite = Sprite;
            }
            else
            {
                Image = GameObject.Find(skillname[15 - 1]).GetComponent<Image>();
                Texture = Resources.Load<Texture2D>(skillname[15 - 1]);
                Sprite = Sprite.Create(Texture, new Rect(0, 0, Texture.width, Texture.height), new Vector2(0.5f, 0.5f));
                Image.sprite = Sprite;
            }
        }
        if (SkillIsUnlocked[7 - 1] == true && SkillIsUnlocked[11 - 1] == true)
        {
            if (SkillIsUnlocked[14 - 1] == false)
            {
                Image = GameObject.Find(skillname[14 - 1]).GetComponent<Image>();
                Texture = Resources.Load<Texture2D>(skillname_unlock[14 - 1]);
                Sprite = Sprite.Create(Texture, new Rect(0, 0, Texture.width, Texture.height), new Vector2(0.5f, 0.5f));
                Image.sprite = Sprite;
            }
            else
            {
                Image = GameObject.Find(skillname[14 - 1]).GetComponent<Image>();
                Texture = Resources.Load<Texture2D>(skillname[14 - 1]);
                Sprite = Sprite.Create(Texture, new Rect(0, 0, Texture.width, Texture.height), new Vector2(0.5f, 0.5f));
                Image.sprite = Sprite;
            }
        }
    }

    public void GetSkillStatus(int Status)
    {
        
        SkillStatus = Status;
    }

    public void TreeGetSkillUnlock(int UnlockNumber)
    {
        SkillIsUnlocked[UnlockNumber - 1] = true;
    }

    public void levelup()
    {
        if (BEUi.CurrentBENum > 10)
        {
            BEUi.expendEnergy(10);
            SkillLevel[SkillStatus - 1] += 1;
        }
    }
}
