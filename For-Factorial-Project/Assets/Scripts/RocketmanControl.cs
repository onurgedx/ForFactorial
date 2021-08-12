using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketmanControl : MonoBehaviour
{
    [SerializeField]
    private GameObject controller;

    [SerializeField]
    private MotionRocket hareket2;

    private string touchName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        touchNameUpdate();

        Invoke(touchName, 0.0f);


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

    private void touchNameUpdate()
    {
        touchName = controller.transform.GetChild(0).gameObject.name;
    }

}