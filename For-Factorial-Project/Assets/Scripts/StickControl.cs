using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickControl : MonoBehaviour
{
    [SerializeField]
    private GameObject controller;

    [SerializeField]
    private Motion hareket;

    private string touchName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        touchNameUpdate();

        Invoke(touchName,0.0f);
        

    }
    private void SlideRight()
    {
        hareket.SlideRight();

    }

    private void SlideLeft()
    {
        hareket.SlideLeft();
    }
    
    private void NoTouching()
    {
        hareket.NoTouching();

    }
    

    private void NoMoving()
    {
        hareket.NoMoving();
            }

    private void touchNameUpdate()
    {
        touchName =controller.transform.GetChild(0).gameObject.name; 
    }

}
