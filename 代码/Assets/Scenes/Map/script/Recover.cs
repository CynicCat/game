using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject warnning;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        warnning.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if(BEUi.CurrentBENum>0)
        { 
        BEUi.expendEnergy(1);
        playerHealth.heal();
        playerHealth.Noshow();
        }
        else
        {
            warnning.SetActive(true);
            StartCoroutine(NoShowWarnning());
        }

    }

    public void cancel()
    {
        playerHealth.Noshow();
    }

    IEnumerator NoShowWarnning()// ‹…ÀºÏ≤‚
    {
        yield return new WaitForSeconds(1);
        warnning.SetActive(false);
    }
}
