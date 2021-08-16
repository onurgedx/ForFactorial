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


        rocketmanRG.velocity = new Vector3(0f, power*400, power*200);

        
    }
}
