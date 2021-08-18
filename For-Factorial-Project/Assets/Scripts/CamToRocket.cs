using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamToRocket : MonoBehaviour
{
    [SerializeField]
    private GameObject rocketman;

    public GameObject rocket;

    private Vector3 camRefBeginLocal;
    private Vector3 camRef;

    // Start is called before the first frame update
    private void Start()
    {
        CamRefBeginCatch();


    }

    // Update is called once per frame
    
    private void FixedUpdate()
    {
        
        camBack();


        follow();

        
    
    }



    private void CamRefBeginCatch()
    {
        camRefBeginLocal = rocketman.transform.localPosition;
    }


    private void follow()
    {
        setPos();


        rotationChange();



    }

    private void rotationChange()
    {


        transform.rotation = Quaternion.Slerp(transform.rotation, rocketman.transform.rotation, 0.30f);


    }

  


    private void camBack()
    {

        Vector3 xyzV = Camera.main.WorldToViewportPoint(rocket.transform.position);

         CamRefRotationSet();

        if(xyzV[0]>0 &&xyzV[1]>0 && xyzV[0]<1 && xyzV[1]<1f )
        {
            rocketman.transform.localPosition = Vector3.Slerp(rocketman.transform.localPosition, camRefBeginLocal, Time.deltaTime*4);

        }
        else
        {
           rocketman.transform.localPosition = Vector3.Lerp(rocketman.transform.localPosition, rocketman.transform.localPosition- rocketman.transform.forward*6*Mathf.Abs(xyzV[1]),1/(Mathf.Abs(xyzV[1]))) ;

        }

       




    }

    private void CamRefRotationSet()
    {
        rocketman.transform.rotation = Quaternion.Lerp(rocketman.transform.rotation, Quaternion.LookRotation(-rocketman.transform.position + rocket.transform.position), Time.deltaTime / 2);

    }



    private void setPos()
    {
        camRef = rocketman.transform.position;
        transform.position = new Vector3(posXSet(), posYSet(), posZSet());

    }

    private float posXSet()
    {
        return Mathf.Lerp(transform.position.x, camRef.x, 0.25f);
    }
    private float posYSet()
    {
        return Mathf.Lerp(transform.position.y, camRef.y, 0.18f);
    }

    private float posZSet()
    {
        return Mathf.Lerp(transform.position.z, camRef.z, 0.45f);
    }


}


// Debug.Log(Camera.main.WorldToScreenPoint(rocket.transform.position));
// Debug.Log(Camera.main.WorldToViewportPoint(rocket.transform.position)); //0 ile 1 arasýnda degerler verir x icin 
