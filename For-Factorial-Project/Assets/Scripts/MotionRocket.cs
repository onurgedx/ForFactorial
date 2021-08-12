using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionRocket : MonoBehaviour
{
    public Animator animator;

    public Animator animator2;

    private float timeOfAni(float time)
    {
        return Mathf.Clamp(time, 0f, 0.99f);
    }

    
    
    public void SlideRight()
    {
      
         animator2.SetFloat("direction", timeOfAni(animator2.GetFloat("direction") - Time.deltaTime*2));

       


    }

    public void SlideLeft()
    {
        
        animator2.SetFloat("direction", timeOfAni(animator2.GetFloat("direction") + Time.deltaTime * 2));

    }

    public void NoMoving()
    {
        animator.SetFloat("time", timeOfAni(animator.GetFloat("time") + Time.deltaTime*5));
        animator2.SetFloat("direction", Mathf.Lerp(animator2.GetFloat("direction"), 0.5f, Time.deltaTime));
    }

    public void NoTouching()
    {
        
          animator2.SetFloat("direction", 0.5f);

      animator.SetFloat("time", timeOfAni(animator.GetFloat("time") - Time.deltaTime*5));
        
    }
}
