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

    private Vector3 Pos0;
    private Quaternion Rot0;

    private float departure =1f;

    // Start is called before the first frame update
    private void Start()
    {
        CamRefBeginCatch();

        RecordPosRot0();

    }

    // Update is called once per frame
    
    private void FixedUpdate()
    {
        
        camBack();


        follow();

        
    
    }

    private void RecordPosRot0()
    {
        Pos0 = transform.position;
        Rot0 = transform.rotation;
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


        transform.rotation = Quaternion.Lerp(transform.rotation, rocketman.transform.rotation, 0.1f);


    }

  
    private void CamRefRotationSet()
    {
        rocketman.transform.rotation = Quaternion.Lerp(rocketman.transform.rotation, Quaternion.LookRotation(-rocketman.transform.position + rocket.transform.position), 1);
       //rocketman.transform.rotation = Quaternion.Euler(Vector3.Lerp(rocketman.transform.rotation.eulerAngles, Quaternion.LookRotation(-rocketman.transform.position + rocket.transform.position,Vector3.forward).eulerAngles, Time.deltaTime));
    }

    private void camBack()
    {

        Vector3 xyzV = Camera.main.WorldToViewportPoint(rocket.transform.position);

         

        if(xyzV[0]>0 &&xyzV[1]>0 && xyzV[0]<1 && xyzV[1]<1f )
        {
            rocketman.transform.localPosition = Vector3.Lerp(rocketman.transform.localPosition, camRefBeginLocal, Time.deltaTime*4);

        }
        else
        {
           rocketman.transform.position = Vector3.Lerp(rocketman.transform.position, rocketman.transform.position- rocketman.transform.forward*6,1/(Mathf.Abs(xyzV[1]))) ;

        }

       




    }

    private void camRefDetermine()
    {

        


     if (rocket.transform.parent == null)
        {


        }
        else if (rocket.transform.parent != null)
        {
            rocketman.transform.position = Pos0;
            rocketman.transform.rotation = Rot0;
            departureDecrease();


        }


        camRef = rocketman.transform.position;

       
       



    }


    private void setPos()
    {
       camRefDetermine();
        transform.position = new Vector3(posXSet(), posYSet(), posZSet());

    }


    private void departureDecrease()
    {
        departure = rocket.GetComponent<RestartSmoothly>().time2h;
    }


    private float posXSet()
    {
        return Mathf.Lerp(transform.position.x, camRef.x, 0.20f*departure);
    }
    private float posYSet()
    {
        return Mathf.Lerp(transform.position.y, camRef.y, 0.18f * departure);
    }

    private float posZSet()
    {
        return Mathf.Lerp(transform.position.z, camRef.z, 0.15f * departure);
    }


}


// Debug.Log(Camera.main.WorldToScreenPoint(rocket.transform.position));
// Debug.Log(Camera.main.WorldToViewportPoint(rocket.transform.position)); //0 ile 1 arasýnda degerler verir x icin 
