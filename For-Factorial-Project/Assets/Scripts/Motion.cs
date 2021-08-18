using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Animator animator;

    public LeavePotentionFree lPF;

    public StickControl sControl;

    private float timeOfAni(float time)
    {
        return Mathf.Clamp(time, 0f, 1f);
    }

    private float get_xDiff()
    {
        return sControl.get_xDiff();
    }

    public void SlideRight()
    {
        Slide();

    }
    
    public void SlideLeft()
    {
        Slide();

    }

    public void Slide()
    {
        animator.SetFloat("time", timeOfAni(animator.GetFloat("time") - get_xDiff()/2f));
        // animator.SetFloat("time", timeOfAni(2*Mathf.Abs(get_xDiff())));
    }

    public void NoMoving()
    {
        animator.SetFloat("time", timeOfAni(animator.GetFloat("time")));
    }

    public void NoTouching()
    {
        if (animator.GetFloat("time") > 0.1f)
        {

            lPF.enabled = true;

        }
        else
        {
            animator.SetFloat("time", 0f);
        }
    }




}
