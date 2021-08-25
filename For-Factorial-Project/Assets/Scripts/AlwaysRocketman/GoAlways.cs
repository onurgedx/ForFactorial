using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAlways : MonoBehaviour
{

    public Rigidbody rg;

    public float Amount;

    private float Propel=1f;

    // Update is called once per frame
    private void FixedUpdate()
    {

        go();
    }


    private void go() 
    {

        Vector3 a = transform.TransformVector(Vector3.forward * Amount )*Propel;
        
        rg.velocity = new Vector3(a.x, rg.velocity.y, a.z);
        


        
    }

    public IEnumerator PropelInstant()
    {
        float t = 0;
        
        while(Propel!=3f)
        {
            t += Time.deltaTime;
            Propel = Mathf.Lerp(1f,3f,t );
            yield return null;
        }

        while(Propel!=1f)

        {
            t -= Time.deltaTime;
            Propel = Mathf.Lerp(1f, 3f, t);
            yield return null;
        }



    }


}
