using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BEUi : MonoBehaviour
{
    public int startBENum;//初始能源数量
    public Text BENum;//显示

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

    public static void expendEnergy(int num)//消耗能源块
    {
        CurrentBENum -= num;
    }
}
