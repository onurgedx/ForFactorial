using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckParent : MonoBehaviour
{
    [SerializeField]
    private FallAlways fall;

    [SerializeField]
    private GoAlways go;

   // Update is called once per frame
   private void Update()
    {
        if(transform.parent==null)
        {
            beingOnline();

            beSelfOffline();
        }
    }


    private void beingOnline()
    {
        
        fallOnline();

        goOnline();
    }

    private void fallOnline()
    {
        fall.enabled = true;

    }

    private void goOnline()
    {
        go.enabled = true;
    }


    private void beSelfOffline()
    {
        this.enabled = false;

    }


}
