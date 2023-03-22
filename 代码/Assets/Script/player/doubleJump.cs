using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleJump : MonoBehaviour
{
    // Start is called before the first frame update
    public float destroytime = 0.1f;
    void Start()
    {
        Destroy(gameObject,destroytime);
    }

    // Update is called once per frame
}
