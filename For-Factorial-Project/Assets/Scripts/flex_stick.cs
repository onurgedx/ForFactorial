using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flex_stick : MonoBehaviour
{

    private float flexAspect=0f; // the aspect of flexing
    
    private float clock_ending; // it increases unless touching

    public float maxflex = 20f; // max aspect for flexing

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        touchThings();

        
        

      


        
    }


    private void touchThings()
    {
        if (Input.touchCount > 0)
        {
            clock_ending = 0f;
            Touch finger = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToViewportPoint(new Vector3(finger.position[0], finger.position[1], 0f));
            

            if (finger.phase != TouchPhase.Began)
            {
                float slideAmountX = touchPosition[0] - finger.deltaPosition[0]; 

                if (Mathf.Abs(slideAmountX) < 1f)
                {
                    slideAmountX = 0;
                }
                else
                {
                    slideAmountX /= Mathf.Abs(slideAmountX);
                }


                //this line ensures that pulling the stick makes it harder pulling the stick
                slideAmountX = Mathf.Lerp( 0,slideAmountX, (maxflex - flexAspect*slideAmountX) / maxflex);
                    
                flexAspect = Mathf.Clamp(flexAspect +   slideAmountX, 0f, maxflex);

                flex();

            }

        }
        else
        {
            Throw();
        }

    }

    private void Throw()
    {

        flexAspect = Mathf.Lerp(flexAspect, 0f, clock_ending*clock_ending);


        clock_ending += Time.deltaTime * 2f;

        flex();
        


    }

    

    private void flex()
    {

       
        transform.localRotation = Quaternion.Euler(-flexAspect, 0f, 0f);
        


    }

}


