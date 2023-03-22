using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Removebehavior : StateMachineBehaviour
{
    //ÒÆ³ýenemy
    public float timerun = 0.5f;
    private float timeelapsed = 0f;
    SpriteRenderer spriteRenderer;
    GameObject objectremove;
    Color startcolor;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeelapsed = 0f;
        spriteRenderer = animator.GetComponent<SpriteRenderer>();
        objectremove = animator.gameObject;
        startcolor = spriteRenderer.color;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeelapsed += Time.deltaTime;
        float newAlpha =startcolor.a* (1 - (timeelapsed/timerun));
        spriteRenderer.color = new Color(startcolor.r, startcolor.g, startcolor.b, newAlpha);
        if (timeelapsed > timerun) 
        {
            Destroy(objectremove);
        }
    }


}
