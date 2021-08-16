using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamToRocket : MonoBehaviour
{
    [SerializeField]
    private GameObject rocketman;

    public GameObject rocket;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    private void FixedUpdate()
    {

        follow();
       
        

    
    }






    private void follow()
    {
        setPos();

        rotationChange();



    }

    private void rotationChange()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rocket.transform.rotation, 0.15f);

    }

    private void lookToRocket()
    {
        transform.LookAt(rocket.transform);
    }

    


    private void setPos()
    {
        transform.position = new Vector3(posXSet(), posYSet(), posZSet());

    }

    private float posXSet()
    {
        return Mathf.Lerp(transform.position.x, rocketman.transform.position.x, 0.35f);
    }
    private float posYSet()
    {
        return Mathf.Lerp(transform.position.y, rocketman.transform.position.y, 0.10f);
    }

    private float posZSet()
    {
        return Mathf.Lerp(transform.position.z, rocketman.transform.position.z, 0.15f);
    }


}
