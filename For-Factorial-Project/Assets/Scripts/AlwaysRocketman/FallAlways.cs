using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAlways : MonoBehaviour
{
    public Rigidbody rg;

    public FallWithGlider fallGlider;

    public float Amount;

    // Update is called once per frame
    private void FixedUpdate()
    {
        fall();
    }


    private void fall()
    {
        rg.velocity -= transform.TransformDirection(Vector3.up*Amount*Time.fixedDeltaTime);




    }

    private void OnEnable()
    {
        fallGlider.enabled = false;
        
    }


}
