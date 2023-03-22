using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOneShotBehavior4 : StateMachineBehaviour
{
    public AudioClip soudToPlay;//��Ч
    public float volume = 1f;//����
    public bool playOnEnter = true, playOnExit = true, playAfterDelay = false;
    public float palyDelay = 0.25f;
    private float timeSinceEnter = 0;
    private float timeSinceExit = 0;
    private bool hasDelay = false;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playOnEnter)
        {
            AudioSource.PlayClipAtPoint(soudToPlay, animator.gameObject.transform.position, volume);
        }
        timeSinceEnter = 0f;
        hasDelay = false;
    }

    //OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playAfterDelay && !hasDelay)
        {
            timeSinceEnter += Time.deltaTime;
            if (timeSinceEnter > palyDelay)
            {
                AudioSource.PlayClipAtPoint(soudToPlay, animator.gameObject.transform.position, volume);
                hasDelay = true;
            }
        }
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playOnExit)
        {
            AudioSource.PlayClipAtPoint(soudToPlay, animator.gameObject.transform.position, volume);
        }
    }

}
