using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemy_healthybar : MonoBehaviour
{
    public Image bar;
    public float health, maxhealth = 100f;
    private void Update()
    {
        BarFiller();
    }
    private void BarFiller()
    {
        bar.fillAmount = health / maxhealth;
}
}
