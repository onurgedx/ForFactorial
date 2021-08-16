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
        return animator.GetFloat("time") > 0.9f;
    }
    public void SlideRight()
    {
      
        if(AccesForSlide())
        { 
         animator2.SetFloat("direction",Mathf.Lerp(animator2.GetFloat("direction"),0,Time.deltaTime*5));
            gravityRocket.rightOnline();
        }


    }

    public void SlideLeft()
    {
        if (AccesForSlide())
        {


            animator2.SetFloat("direction", Mathf.Lerp(animator2.GetFloat("direction"), 1, Time.deltaTime*5));

            gravityRocket.leftOnline();

        }
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
        fliper.transform.Rotate(fliper.transform.TransformDirection(Vector3.right), 1800*Time.deltaTime);
       
    }

    public void ResetFlipFlop()

    {
        fliper.transform.localRotation = Quaternion.Slerp(fliper.transform.localRotation,Quaternion.Euler(0, 0, 0),0.15f);
    }
}
