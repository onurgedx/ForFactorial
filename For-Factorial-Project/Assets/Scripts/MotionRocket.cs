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

    public RocketmanControl RMControl;



    


    private float timeOfAni(float time,float min=0,float max=0.99f)
    {
        return Mathf.Clamp(time, min  , max);
    }

    private float getXDiff()
    {
        return timeOfAni(RMControl.get_xDiff(),-0.5f,0.49f);
    }

    private bool AccesForSlide()
    {
        return animator.GetFloat("time") >= 0.0f;
    }
    public void SlideRight()
    {
      
        if(AccesForSlide())
        {
        

            Slide();

            gravityRocket.rightOnline();
        }


    }

    public void SlideLeft()
    {
        if (AccesForSlide())
        {
            

            Slide();

            gravityRocket.leftOnline();

        }
    }



    public void Slide()
    {
        animator2.SetFloat("direction", 0.5f-getXDiff());
    }

    public void NoMoving() 
    {

        LeftRightDecision();
        gravityRocket.FallGlider();
        ResetFlipFlop();
        //animator2.SetFloat("direction", Mathf.Lerp(animator2.GetFloat("direction"), 0.5f, Time.deltaTime));
        
        animator.SetFloat("time", timeOfAni(animator.GetFloat("time") + Time.deltaTime*5));
        
       
    }

    public void NoTouching()
    {
        gravityRocket.FallAlways();


        LeftRightDecision();

        animator2.SetFloat("direction", Mathf.Lerp(animator2.GetFloat("direction"), 0.5f, 0.5f));

     
        animator.SetFloat("time", timeOfAni(animator.GetFloat("time") - Time.deltaTime*4));

        flipflop();
        
    }

    public void Nothing()
    {
        NoTouching();

    }

    private void LeftRightDecision()
    {
       // gravityRocket.RightLeftOffline();

        if (animator2.GetFloat("direction")>0.5f)
        {
            //gravityRocket.leftOnline();
            gravityRocket.rightOffline();
        }
        else if(animator2.GetFloat("direction")<0.5f)
        {
            //gravityRocket.rightOnline();
            gravityRocket.leftOffline();
        }
        

    }

    




    public void flipflop()
    {
        fliper.transform.Rotate(transform.right, 1800*Time.deltaTime);
       
    }

    public void ResetFlipFlop()

    {
        fliper.transform.localRotation = Quaternion.Slerp(fliper.transform.localRotation,Quaternion.Euler(0, 0, 0),0.15f);
    }
}
