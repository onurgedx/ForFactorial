using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : MonoBehaviour
{

    public TrailRenderer trailwing;


    public Animator animator;

   

    // Update is called once per frame
    private void Update()
    {

        trailOnOff();



    }

    private void trailOnOff()
    {
        if (animator.GetFloat("time") > 0.9f)
        {
            trailwing.enabled = true;
        }
        else { trailwing.enabled = false; }
    }
}
