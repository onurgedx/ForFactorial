using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamToRocket : MonoBehaviour
{
    [SerializeField]
    private GameObject rocketman;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    private void FixedUpdate()
    {


        transform.position = new Vector3(posXSet(), posYSet(), posZSet());
          

        transform.rotation = Quaternion.Slerp(transform.rotation, rocketman.transform.rotation, 0.05f);


        //Vector3.SmoothDamp(transform.position, rocketman.transform.position, new Vector3(0, 0, 1f), 0.2f);



    }


    private float posXSet()
    {
        return Mathf.Lerp(transform.position.x, rocketman.transform.position.x, 0.15f);
    }
    private float posYSet()
    {
        return Mathf.Lerp(transform.position.y, rocketman.transform.position.y, 0.35f);
    }

    private float posZSet()
    {
        return Mathf.Lerp(transform.position.z, rocketman.transform.position.z, 0.15f);
    }


}
