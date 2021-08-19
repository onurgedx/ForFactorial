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


    public AudioSource Asource;


    List<IEnumerator> ienu = new List<IEnumerator>();

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


    private void AudioSourcePlayProgress()
    {
        //Asource.pitch +=Asource.pitch/(10+ienu.Count) ;

        Asource.Play();
    }
    
    private IEnumerator  ColorSwich(GameObject go)
    {
        AudioSourcePlayProgress();

        Color tempColor = go.GetComponent<MeshRenderer>().material.color;

        go.GetComponent<MeshRenderer>().material.color = Color.white;

        while (tempColor!= go.GetComponent<MeshRenderer>().material.color)
        {

            go.GetComponent<MeshRenderer>().material.color = Color.Lerp(go.GetComponent<MeshRenderer>().material.color, tempColor,Time.deltaTime);
           
            yield return null;
            

        }

       

       
        

    }


    private void AddAndBlow(GameObject go)
    {
        ienu.Add(ColorSwich(go));
        StartCoroutine(ienu[ienu.Count - 1]);
    }


    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "plane")
        {
            

            
        }
        else { 
        

          if(collision.gameObject.tag =="silindirPink")
        {   
            
            if(collision.collider.bounds.max.y <= gameObject.GetComponent<BoxCollider>().bounds.center.y)
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
            AddAndBlow(collision.gameObject);


        }
       



        



    }


}
