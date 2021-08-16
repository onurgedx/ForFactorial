using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnLeft : MonoBehaviour
{

    public Animator animator;

    // Update is called once per frame
    private void Update()
    {
        rotateIt();

    }
    
    private void rotateIt()
    {
        float direc =  animator.GetFloat("direction")- 0.5f;
        //transform.localRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - 60 * Time.deltaTime *direc , 0);

        transform.Rotate(Vector3.up, -direc * 60 * Time.deltaTime);

    }
}
