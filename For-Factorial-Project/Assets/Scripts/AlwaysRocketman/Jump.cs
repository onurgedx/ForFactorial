using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody rg;

    public float power=300f;
    private void OnEnable()
    {
        //VeloUpIncrease();

        SekRaki();

        BeOffline();
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
