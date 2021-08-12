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


        transform.position = Vector3.Slerp(transform.position, rocketman.transform.position, 0.15f);

        transform.rotation = Quaternion.Slerp(transform.rotation, rocketman.transform.rotation, 0.05f);


        //Vector3.SmoothDamp(transform.position, rocketman.transform.position, new Vector3(0, 0, 1f), 0.2f);



    }
}
