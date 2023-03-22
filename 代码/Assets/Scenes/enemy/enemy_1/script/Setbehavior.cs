using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setbehavior : StateMachineBehaviour
{   
    public string boolname;
    public bool updateState;
    public bool updateStateMachine;
    public bool valueOnEnter, valueOnExit;


    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateState)
        {
            animator.SetBool(boolname, valueOnEnter);
        }
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateState)
        {
            animator.SetBool(boolname, valueOnExit);            
        }
    }

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        if(updateStateMachine)
        animator.SetBool(boolname, valueOnEnter);
    }

    //onstatemachineexit is called when exiting a state machine via its exit node
    override public void OnStateMachineExit(Animator animator, int stateMachinePathhash)
    {
        if (updateStateMachine)
            animator.SetBool(boolname, valueOnExit);
    }
}
