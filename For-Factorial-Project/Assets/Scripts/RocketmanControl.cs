using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketmanControl : MonoBehaviour
{
    [SerializeField]
    private GameObject controller;

    [SerializeField]
    private MotionRocket hareket2;

    private string touchName,touchName2;

    private string[] touchNames = new string[2];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        Main();

    }
    
    private void Main()
    {
        touchNamesUpdate();

        touchsPlay();



    }
    
    private void touchNamesUpdate()
    {
        touchNameUpdate();

        touchName2Update();



    }
    
    private void touchNameUpdate()
    {
        touchNames[0] = controller.transform.GetChild(0).gameObject.name;

    }
    private void touchName2Update()
    {
        if (controller.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            touchNames[1] = controller.transform.GetChild(1).gameObject.name;
        }
        else
        {
            touchNames[1] = null;
        }

    }

    private void touchsPlay()
    {
        foreach(string touchName in touchNames)
        { 
            if(touchName!=null)
            { 
            Invoke(touchName, 0.0f);
            }
        }

    }
    
    public float get_xDiff()
    {
        return controller.GetComponent<Controller>().get_xdiff();
    }



    private void SlideRight()
    {
        hareket2.SlideRight();

    }

    private void SlideLeft()
    {
        hareket2.SlideLeft();
    }

    private void NoTouching()
    {
        hareket2.NoTouching();

    }


    private void NoMoving()
    {
        hareket2.NoMoving();
    }

   

}