using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BEUi : MonoBehaviour
{
    public int startBENum;//��ʼ��Դ����
    public Text BENum;//��ʾ

    public static int CurrentBENum;
    // Start is called before the first frame update
    void Start()
    {
        CurrentBENum = startBENum;
    }

    // Update is called once per frame
    void Update()
    {
        BENum.text = CurrentBENum.ToString();
    }

    public static void expendEnergy(int num)//������Դ��
    {
        CurrentBENum -= num;
    }
}
