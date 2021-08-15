using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOn : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rg;

    public float jumpPower = 1000f;

    public void gravitySetOne()
    {

        rg.useGravity = true;

      
    }

    public void gravitySetOff()
    {
        rg.useGravity = false;
    }

   



    public void dragAndForceForward(float x)
    {
        SetDrag10();
        forceToForward(x);
    }

    private void forceToForward(float x)

    {
        

        rg.AddForce(new Vector3(x * 2, 0, 1f)*600, ForceMode.Acceleration);
    }

    


    private void SetDrag10()
    {
        rg.drag = 10f;
    }
    
    public void SetDrag0()
    {
        rg.drag = 0f;

    
   }


    private void TwoXUp()
    {
        SetDrag0();
        rg.AddForce(new Vector3(0, 1, 0) *jumpPower*2);

    }



    private void OnceXUp()
    {
        SetDrag0();
        rg.AddForce(new Vector3(0, 1, 0) * jumpPower);

    }




    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="silindirPink")
        {
            Debug.Log("silindir");
            OnceXUp();
        }

        else if(collision.gameObject.tag=="prizmaBlue")
        {
            Debug.Log("prizma");
            TwoXUp();


        }
        else if (collision.gameObject.tag == "plane")
        {


            Debug.Log("plane");
        }


    }


}
