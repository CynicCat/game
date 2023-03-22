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

    string[] skillname_TMP = { "������", "���", "����", "����ֵ����", "��ս�˺����", "Զ���˺����", "��֮��", "ԡ�ײ���", "����", "��������", "��Ϣ", "�ٶ�����", "�ش�", "����", "ʥ��" };
    string[] skillbackground_TMP = { "���ټ�Ԫ���������ڽ�ֹ�Ǿ������׷��У����ڸ��ӻ����Ĺ������󣬹ھ��Ƽ�����˶�ʱչ������������������У����ڿͻ�ǿ��Ҫ���½�������������Ϊ�������Ρ�", "����Զ������ս����Ħ���Ǵ��ڼ䣬����С���ǵر���ս������ھ��Ƽ���˾���Ƶ���ս����ʽ�����������ػ���ʧЧ����µĶ̾�����ս���󣬿���ʵ��С��Χ������ս��","Զ��ʱ�ڣ��ܲ����������ƣ�������սװ�ײ�������ʹ��ߡ���������ǣͷ����ѧԺ����һͬ�о������Ļ�������������ͨ��δ��ٲ�������������ʵ�ֻ�����ٺ�Ķ�����������󽵵���Զ�������׵�����ʡ�","�Ǽ�ֳ��ʱ�ڣ�Զ�����ڿ�Ħ����ϵ�����˸ߴ��ȸ�����Դ�ᾧ�󡣹��ߴ��ȵ���Դ�ᾧ������Ŷ��ײ�������������ڸ��Ӱ���ľ�Ĭ�ɿ�����������ѡ���˸�Ϊ����ʵ�ݵ�װ����ֳ�����������Ȼ��ը�޷���ܣ��Ǿ�����ը��ֻҪû��������ûը��","���ټ�Ԫ��½��ִ�����ӱ������У�����Σ���̶ȵ��ж�������߶���װ�׵�������ʡ�","���ټ�Ԫ��½��ִ�����ӱ������У���Է���ִ���ı�ͽ�����������ơ�����Σ���̶ȵ��ж�������߻��ϵͳ��������ʡ�","��еΣ�������󣬾��������е���Ƶ����˻��ײ��ӿ�����������սϵͳ���Ը���װ�׾��г����������Ĺ����߽⣬���װ������״̬����Ԫ˧����Ϊ��֮�ġ�", "�ڶ��ξ�ս�жΣ�ѧԺ���ָ߲��ѱ䣬��֮����Ŀ����й¶����еһ��ͬ��װ������֮����սϵͳ����Ե�ǰ״�����з������������������Ƴ���ͨ�������ĸ��⣬���Եֿ���֮�Ķ�װ�׵Ĺ����߽⣬�ɲ�ʿ����Ϊԡ�ײ���ϵͳ��", "��еΣ�������󣬾��������е���Ƶ����˻��ײ��ӿ�����������սϵͳ���Ը���װ�׳������������⣬�����谭�������е��䶳Һ������װ���ƶ�����Ԫ˧����Ϊ���ǡ�","�ڶ��ξ�ս�жΣ�ѧԺ���ָ߲��ѱ䣬������Ŀ����й¶����еһ��ͬ��װ���˱�����սϵͳ����Ե�ǰ״�����з������������������Ƴ���ͨ��������ѭ��������ϵ�����Աܿ����Ƕ�װ�׵����ƣ��ɲ�ʿ����Ϊ��������ϵͳ��","��еΣ�������󣬾��������е���Ƶ����˻��ײ��ӿ�����������սϵͳ���Ը���װ�׾��г���ʱ�����ĳ����˺�����Ԫ˧����Ϊ��Ϣ��","�ڶ��ξ�ս�жΣ�ѧԺ���ָ߲��ѱ䣬��Ϣ��Ŀ����й¶����еһ��ͬ��װ���˶�Ϣ��սϵͳ����Ե�ǰ״�����з������������������Ƴ���ͨ����װ�׵��ع������Եֿ���Ϣ��װ�׵ĳ�����ʴ���ɲ�ʿ����Ϊ�ٶ�����ϵͳ��","�з����ڻ��տ�Ħ��ɼ��ĸߴ�����Դ�ᾧ�󣬷�����������ɷḻ����Դ�⣬�����д�ʹ��������һ���̶ȸ�λ�����ԣ��������ڻ��׵ļ�ʱά�ޡ�ģ����Դ�ᾧ�ĸ���Ч����ʿΪ���װ�װ������ϵͳ�����������ʽ�����������������ϣ�������Ϊ�ش�ϵͳ��","�����ξ�ս�ڼ䣬���������ڶ���е��ս���������ơ�Ԫ˧�ƶ��˶���е�����������ս�ƻ���Ϊ��֤ͻ��С�ӵ���ս�����Լ�����ж��ĳɹ��ʣ��ɲ�ʿ�з��Ĵ�����������Ԫ˧��������Ϊ�����С���","�����ξ�ս�ڼ䣬���������ڶ���е��ս���������ơ�Ԫ˧�ƶ��˶���е�����������ս�ƻ���Ϊ��֤ͻ��С�ӵİ�ȫ�Լ�����ж��ĳɹ��ʣ��ɲ�ʿ�з������ͻ��׽ṹ�����Էֵ������ܵ����˺�����Ԫ˧����Ϊ��ʥ�ס���" };
    string[] skilldescription = { "�������ж�����Ծ������", "������ǰ��������һ�ξ��������", "ʹ��ɫ�ڱ����ܺ�ֱ���������ǰ�Ѫԭ�ظ��������Ϸ��һ����Ϸֻ��ʹ��һ��", "��߽�ɫѪ��������100", "��߽�ɫ��ս�˺�10��", "����Զ�̹�����������Ϊ50��", "Ϊ��ɫ��ս�������Ż������˺���Ϊ���˸�������״̬����״̬�´��ܵ��������˺�Ϊ150%", "Ϊ��ɫ����һ�л����Ը���Ч��", "Ϊ��ɫ��ս�������ű������˺���Ϊ���˸��ӱ���״̬����״̬���ƶ������ܵ����ƣ������ƶ��ٶ�10%", "Ϊ��ɫ����һ�б����Ը���Ч��", "Ϊ��ɫ��ս�������Ŷ������˺���Ϊ���˸����ж�״̬����״̬�½�ÿ���ܵ�20�㸯ʴ�˺�", "Ϊ��ɫ����һ�ж����Ը���Ч��", "������+�������������������ָ���ɫ����ֵ,ÿ��ظ�5%", "������+��������������˲�����Χ��λ���5����ս�˺�", "������+������������������Խ�ɫ��ɵ��˺�����Ϊԭ����50%" };
    string[] levelupeffect = { "�ü����޷�������", "�ü����޷�������", "�ü����޷�������","ÿ��������߽�ɫѪ������100��","ÿ��������߽�ɫ��ս�˺�10��","ÿ��������߽�ɫԶ���˺�5��","ÿ��������ǿ����Ч�����˺����10%", "�ü����޷�������","ÿ��������ǿ����Ч�����ƶ��ٶȽ��ͷ�������10%", "�ü����޷�������","ÿ��������ǿ��ʴЧ������ʴ�˺����10��", "�ü����޷�������", "�ü����޷�������", "�ü����޷�������", "�ü����޷�������" };
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
        // UI���������ȡ
        SkillName = GameObject.Find("SkillTree/Background/SkillName");
        SkillBackground = GameObject.Find("SkillTree/Background/SkillBackground");
        SkillDescription = GameObject.Find("SkillTree/Background/SkillDescription");
        LevelUpEffect = GameObject.Find("SkillTree/Background/LevelUpEffect");
        LevelUp = GameObject.Find("SkillTree/Background/LevelUp");
        SkillTips = GameObject.Find("SkillTree/Background/SkillTips");
        EnergyCost = GameObject.Find("SkillTree/Background/LevelUp/Energy/EnergyCost");

        // UI�����ʼ��
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
            SkillBackground.GetComponent<TMP_Text>().text = "���ܱ�����" + skillbackground_TMP[Math.Abs(Status) - 1];
            SkillDescription.SetActive(true);
            SkillDescription.GetComponent<TMP_Text>().text = "����������" + skilldescription[Math.Abs(Status) - 1];
            LevelUpEffect.SetActive(true);
            LevelUpEffect.GetComponent<TMP_Text>().text = "����Ч����" + levelupeffect[Math.Abs(Status) - 1];
            if (Status < 0)
            {
                LevelUp.SetActive(false);
                SkillTips.SetActive(true);
                SkillTips.GetComponent<TMP_Text>().text = "���Ƚ������ܣ�";
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
                    SkillTips.GetComponent<TMP_Text>().text = "��ǰ�����Ѵ�������";
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
