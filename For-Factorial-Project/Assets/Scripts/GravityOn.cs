using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOn : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rg;
   
    public void gravitySetOne()
    {

        rg.useGravity = true;


    }

}
