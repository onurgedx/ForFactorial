using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody rg;

    public float power=300f;
    private void OnEnable()
    {
        rg.velocity += Vector3.up * power;

        this.enabled = false;
    }
}
