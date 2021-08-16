using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOn : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rg;

    public float jumpPower = 1000f;

    public GoAlways go;
    public FallAlways fall;
    public FallWithGlider fallGlider;

    public turnLeft left;
    public turnRight right;

    public Jump jump;

    private void FixedUpdate()
    {




      


    }


    
    public void leftOnline()
    {
        left.enabled = true;
    
   }

    public void rightOnline()
    {
        right.enabled = true;
    }

    public void rightOffline()
    {
        right.enabled = false;

    }
    public void leftOffline()
    {
        left.enabled = false;
    }


    public void RightLeftOffline()
    {
        leftOffline();
        rightOffline();

    }







    public void FallAlways()
    {
        fall.enabled = true;
    }

    public void FallGlider()
    {
        fallGlider.enabled = true;
    }


    public void GoAlways()
    {
        fall.enabled = true;

    }


    

    

   




 
    


  

    private void MoreUp()
    {
        jump.enabled = true;
    }





    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="silindirPink")
        {
            if(collision.collider.bounds.max.y <= collision.contacts[0].point[1])
            {
                MoreUp();



            }  
            
        }

        else if(collision.gameObject.tag=="prizmaBlue")
        {
            if (collision.collider.bounds.max.y   <= collision.contacts[0].point[1])
            {
                MoreUp();
                MoreUp();
            }


        }
        else if (collision.gameObject.tag == "plane")
        {
            

            Debug.Log("plane");
        }


    }


}
