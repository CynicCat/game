using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClearTimerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text timeText;
    float clearTime;
    bool stop = false;

    public GameObject Failure;
    public GameObject Success;
    public GameObject ClearTime;

    void Start()
    {
        Failure = GameObject.Find("ClearTimer/Failure");
        Failure.SetActive(false);
        Success = GameObject.Find("ClearTimer/Success");
        Success.SetActive(false);
        ClearTime = GameObject.Find("ClearTimer/ClearTime");
        ClearTime.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (stop) return;

        clearTime += Time.fixedDeltaTime;
        timeText.text = System.TimeSpan.FromSeconds(value: clearTime).ToString(format: @"mm\:ss\:ff");
    }

    public void GetGameOver(int i)
    {
        stop = true;

        if (i == 1)
        {
            Failure.SetActive(true);
        }
        if (i == 2)
        {
            Success.SetActive(true);
            ClearTime.SetActive(true);
            ClearTime.GetComponent<TMP_Text>().text = "通关时间为：" + timeText.text;
        }
    }
}
