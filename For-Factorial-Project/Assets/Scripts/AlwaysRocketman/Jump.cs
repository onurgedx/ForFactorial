using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody rg;

    public float power=300f;

    public Controller controller;


    private void OnEnable()
    {
        //VeloUpIncrease();
        
        SekRaki();

        NothingIsEveryThing();

        BeOffline();
    //SendMEssage olayýna bakmayi unutma KENDÝME NOT
        
    }


    private void NothingIsEveryThing()
    {
        controller.StopAllCoroutines();
        controller.StartCoroutine("BreakTime");
    }
    


    private void SekRaki()
    {
        rg.velocity = new Vector3(rg.velocity.x, Mathf.Max(rg.velocity.y,0)+power, rg.velocity.z);
    }

    private void VeloUpIncrease()
    {
        rg.velocity += Vector3.up * power;

    }

    private void BeOffline()
    {
        this.enabled = false;
    }

}
