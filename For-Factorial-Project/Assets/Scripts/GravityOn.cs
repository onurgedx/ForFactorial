using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOn : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rg;

    public float jumpPower = 1000f;

    


    private void FixedUpdate()
    {

        
    }


    


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

    public void forceToForward(float x)

    {
        //rg.MoveRotation()
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + x, transform.rotation.eulerAngles.z);
        GoForward();
        //rg.AddForce(new Vector3(x * 2, 0, 1f)*600, ForceMode.Acceleration);
    }

    public void GoForward()
    {
        rg.AddForce(transform.TransformVector(new Vector3(0, 0, 1000*Time.deltaTime)));
    }

    


    private void SetDrag10()
    {
        rg.drag = 0.41f;
    }
    
    public void SetDrag0()
    {
        rg.drag = 0.41f;

    
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
            if(collision.collider.bounds.max.y<=collision.contacts[0].point[1])
            {Debug.Log("silindir");
            OnceXUp();

            }  
            
        }

        else if(collision.gameObject.tag=="prizmaBlue")
        {
            if (collision.collider.bounds.max.y   <= collision.contacts[0].point[1])
            {
                Debug.Log("prizma");
                TwoXUp();
            }


        }
        else if (collision.gameObject.tag == "plane")
        {


            Debug.Log("plane");
        }


    }


}
