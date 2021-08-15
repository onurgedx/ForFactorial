using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionRocket : MonoBehaviour
{
    public Animator animator;

    public Animator animator2;

    public GameObject fliper;

    public GravityOn gravityRocket;

    public float val = 20f;

    private float timeOfAni(float time)
    {
        return Mathf.Clamp(time, 0f , 0.99f);
    }

    

    private bool AccesForSlide()
    {
        return animator.GetFloat("time") > 0.5f;
    }
    public void SlideRight()
    {
      
        if(AccesForSlide())
        { 
         animator2.SetFloat("direction",Mathf.Lerp(animator2.GetFloat("direction"),0,Time.deltaTime*5));
            
        }


    }

    public void SlideLeft()
    {
        if (AccesForSlide())
        {
            animator2.SetFloat("direction", Mathf.Lerp(animator2.GetFloat("direction"), 1, Time.deltaTime*5));

        }
    }

    public void NoMoving()
    {
        ResetFlipFlop();
        animator2.SetFloat("direction", Mathf.Lerp(animator2.GetFloat("direction"), 0.5f, Time.deltaTime));
        
        animator.SetFloat("time", timeOfAni(animator.GetFloat("time") + Time.deltaTime*5));
        
        gravityRocket.dragAndForceForward(0.5f-animator2.GetFloat("direction")); //surtunmeyi arttiriyor

    }

    public void NoTouching()
    {
        gravityRocket.SetDrag0();
        
          animator2.SetFloat("direction", Mathf.Lerp(animator2.GetFloat("direction"), 0.5f, 0.5f));

      animator.SetFloat("time", timeOfAni(animator.GetFloat("time") - Time.deltaTime*4));

        flipflop();
        
    }





    public void flipflop()
    {
        
        fliper.transform.Rotate(fliper.transform.rotation.eulerAngles.x + Time.deltaTime * Mathf.PI * val, fliper.transform.rotation.eulerAngles.y + Time.deltaTime * Mathf.PI * val, fliper.transform.rotation.eulerAngles.z + Time.deltaTime * Mathf.PI * val); 
    }

    public void ResetFlipFlop()

    {
        fliper.transform.rotation = Quaternion.Slerp(fliper.transform.rotation,Quaternion.Euler(0, 0, 0),0.15f);
    }
}
