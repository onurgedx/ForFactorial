using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAlways : MonoBehaviour
{

    public Rigidbody rg;

    public float Amount;

    // Update is called once per frame
    private void FixedUpdate()
    {
        go();
    }


    private void go() 
    {

        Vector3 a = transform.TransformVector(Vector3.forward * Amount);
        Debug.Log(a);
        rg.velocity = new Vector3(a.x, rg.velocity.y, a.z);
        


        print(rg.velocity);
    }

}
