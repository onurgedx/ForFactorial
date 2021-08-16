using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallWithGlider : MonoBehaviour
{
    public Rigidbody rg;

    public FallAlways fall;

    public float Amount;

    // Update is called once per frame
    private void FixedUpdate()
    {
        fallWGlider();


    }


    private void fallWGlider()
    {
        rg.velocity -= transform.TransformDirection(transform.up * Amount * Time.fixedDeltaTime);
    }


    private void OnEnable()
    {
        fall.enabled = false;
        
    }





}
