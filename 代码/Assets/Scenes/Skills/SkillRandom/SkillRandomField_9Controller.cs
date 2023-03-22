using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillRandomField_9Controller : MonoBehaviour
{
    private bool IsShow;
    private bool IsTriggered;
    public GameObject SkillRandomField_9;

    public Image Image;
    public Texture2D Texture;
    public Sprite Sprite;

    public int decision;

    public int first = 0;

    string[] skillname_TMP = { "二段跳", "冲刺", "重生", "生命值增加", "近战伤害提高", "远程伤害提高", "炎之心", "浴炎不灼", "冰魄", "历冰不冻", "毒息", "百毒不侵", "回春", "审判", "圣甲" };
    string[] skillname = { "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "Skill7", "Skill8", "Skill9", "Skill10", "Skill11", "Skill12", "Skill13", "Skill14", "Skill15" };
    string[] ImageName = { "Image1", "Image2", "Image3" };
    string[] ButtonName = { "Button1/Text (TMP)", "Button2/Text (TMP)", "Button3/Text (TMP)" };

    private ArrayList random = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
        SkillRandomField_9 = GameObject.Find("SkillRandom/SkillRandomField_9/Canvas/Background");
        GameObject.Find("SkillRandom/SkillRandomField_9/Canvas/Background/Decide").GetComponent<Button>().interactable = false;
        GameObject.Find("SkillRandom/SkillRandomField_9/Canvas/Background/Reset").GetComponent<Button>().interactable = true;
        SkillRandomField_9.SetActive(false);
        IsShow = false;
    }

    // Update is called once per frame
    void Update()
    {
        UIDisplay();
    }

    void UIDisplay()
    {
        if (Input.GetKeyDown(KeyCode.J) && IsTriggered)
        {
            if (IsShow == false)
            {
                first += 1;
                if (first == 1)
                {
                    GameObject.Find("SkillRandom").SendMessage("Refresh", 10);
                }
                SkillRandomField_9.SetActive(true);
                IsShow = true;
            }
            else
            {
                SkillRandomField_9.SetActive(false);
                IsShow = false;
            }
        }

        if (IsTriggered == false)
        {
            SkillRandomField_9.SetActive(false);
            IsShow = false;
        }

        if (IsShow == true)
        {
            UIGenerate();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            IsTriggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            IsTriggered = false;
        }
    }

    void UIGenerate()
    {
        for (int i = 1; i <= random.Count; i++)
        {
            Image = GameObject.Find(ImageName[i - 1]).GetComponent<Image>();
            Texture = Resources.Load<Texture2D>(skillname[Convert.ToInt32(random[i - 1]) - 1]);
            Sprite = Sprite.Create(Texture, new Rect(0, 0, Texture.width, Texture.height), new Vector2(0.5f, 0.5f));
            Image.sprite = Sprite;

            GameObject.Find(ButtonName[i - 1]).GetComponent<TMP_Text>().text = skillname_TMP[Convert.ToInt32(random[i - 1]) - 1];
        }
    }

    public void ReceiveRandom(ArrayList Random)
    {
        random = Random;
    }

    public void Button1()
    {
        decision = 1;
        GameObject.Find("Decide").GetComponent<Button>().interactable = true;
    }

    public void Button2()
    {
        decision = 2;
        GameObject.Find("Decide").GetComponent<Button>().interactable = true;
    }

    public void Button3()
    {
        decision = 3;
        GameObject.Find("Decide").GetComponent<Button>().interactable = true;
    }

    public void Reset()
    {
        GameObject.Find("SkillRandom").SendMessage("Refresh", 10);
        GameObject.Find("Reset").GetComponent<Button>().interactable = false;
        GameObject.Find("Decide").GetComponent<Button>().interactable = false;
    }

    public void Decide()
    {
        GameObject.Find("Reset").GetComponent<Button>().interactable = false;
        GameObject.Find("Button1").GetComponent<Button>().interactable = false;
        GameObject.Find("Button2").GetComponent<Button>().interactable = false;
        GameObject.Find("Button3").GetComponent<Button>().interactable = false;

        GameObject.Find("SkillRandom").SendMessage("RandomGetSkillUnlock", Convert.ToInt32(random[decision - 1]));
        GameObject.Find("SkillTree").SendMessage("TreeGetSkillUnlock", Convert.ToInt32(random[decision - 1]));
        GameObject.Find("SkillTree").SendMessage("StatusGetSkillUnlock", Convert.ToInt32(random[decision - 1]));

        SkillRandomField_9.SetActive(false);
        IsShow = false;
    }
}