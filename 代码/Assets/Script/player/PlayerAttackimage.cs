using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackimage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Attack_zero;
    void Start()
    {
        Attack_zero.SetActive(false);

    }
    public void enActive()
    {
        Attack_zero.gameObject.SetActive(true);
    }
    public void disActive()
    {
        Attack_zero.SetActive(false);
    }
    // Update is called once per frame

}
