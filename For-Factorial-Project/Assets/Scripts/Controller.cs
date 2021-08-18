using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject SlideLeft, SlideRight, NoTouching, NoMoving;

    private float[] touches = new float[2]; // single dimentional 2 floats

    public float x_diff;
    public float x_begin;


    // Start is called before the first frame update
    private void Start()
    {


        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        setOffAll();


        touchProgress();
        

    }



    private void setOffAll()//Controller altindaki butun gameobjectleri false yapar
    {
        SlideLeft.SetActive(false);
        SlideRight.SetActive(false);
        NoMoving.SetActive(false);
        NoTouching.SetActive(false);
    }


    private void touchProgress()
    {
        if (AnyTouch())
        {
            ThereIsTouch();




        }
        else
        {
            NoTouchingActive();

        }
    }

    
    private void ThereIsTouch()
    {
        Touch finger = Input.GetTouch(0);
        
            
        if (IsTouchBegan(finger.phase))
        {
            touchesReset(finger.position[0]);


        }

        else if (AnyMove(finger.phase))
        {
            afterMove(finger);

        }
        else if(IsTouchStationary(finger.phase))
        {
            
            NoMovingActive();

        }

    }

    private void afterMove(Touch finger)
    {
        touchUpdate(finger.position[0]);// dokunma gecmisini ve simdisini guncelliyor

         

       if (isMoveToRight())
        {
            SlideRightActive();

        }
        else if (isNoMoveX())
        {
            NoMovingActive();
        }
        else
        {
            SlideLeftActive();
        }

    }

    private bool IsTouchBegan(TouchPhase fingerPhase) // dokunma basladi mi
    {
        
        return fingerPhase == TouchPhase.Began;


    }

    private bool IsTouchStationary(TouchPhase fingerPhase)
    {
        return fingerPhase == TouchPhase.Stationary;
    }

    private bool AnyMove(TouchPhase fingerPhase)// hareket var mi
    {
        return fingerPhase == TouchPhase.Moved;
    }
    

    private bool isNoMoveX()
    {
        return touches[0] == touches[1];
    }

    private  bool isMoveToRight()
    {
        return (touches[0] > touches[1]);
    }

    
    public float get_xdiff()
    {
        
        return x_diff;
     
    }
    private void x_diffEnsure()
    {
        x_diff = (touches[0] - x_begin)/(Camera.main.scaledPixelWidth);
            



       //  Debug.Log(x_diff);
        //Debug.Log(Camera.main.scaledPixelWidth);

    }
    private void touchUpdate(float fingerPosX)
    {
        


        touches[1] = touches[0];
        touches[0] = fingerPosX;

        x_diffEnsure();

    }
    private void touchesReset(float fingerPosX)
    {

        //dokunma kayitlarini guncelliyor.
        touches[0] = fingerPosX;
        touches[1] = touches[0];

        x_begin = touches[0];

    }

   

    private bool AnyTouch()
    {
        return (Input.touchCount > 0);
    }
    private void NoTouchingActive()
    {
        //dokunma yok bunu aktif ediyor
        NoTouching.SetActive(true);
    }


    private void SlideLeftActive()
    {
        //sola kaydýrma SlideLeft i aktif ediyor
        SlideLeft.SetActive(true);
    }

    private void SlideRightActive()
    {
        //saga kaydirma  bunu aktif ediyor
        SlideRight.SetActive(true);
    }

    private void NoMovingActive()
    {
        // hareket yok + dokunma var ise bu aktif oluyor
        NoMoving.SetActive(true);
    }



}
