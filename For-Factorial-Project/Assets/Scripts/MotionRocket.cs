using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionRocket : MonoBehaviour
{
    public Animator animator;

    

    private float timeOfAni(float time)
    {
        return Mathf.Clamp(time, 0f, 1f);
    }

    public void SlideRight()
    {
       // animator.SetFloat("time", timeOfAni(animator.GetFloat("time") - Time.deltaTime));

    }

    public void SlideLeft()
    {
       // animator.SetFloat("time", timeOfAni(animator.GetFloat("time") + Time.deltaTime));

    }

    public void NoMoving()
    {
       // animator.SetFloat("time", timeOfAni(animator.GetFloat("time")));
    }

    public void NoTouching()
    {
    }
}
