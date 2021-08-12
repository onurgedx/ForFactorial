using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnEnable : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rocketmanRG;

    [SerializeField]
    public float power;


    private void OnEnable()
    {


        rocketmanRG.AddForce(0f, power*2000, power*2000);

        
    }
}
