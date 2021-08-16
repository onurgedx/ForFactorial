using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnRight : MonoBehaviour
{

    public Animator animator;


    private void Update()
    {
        rotateIt();

        Debug.Log(transform.rotation.eulerAngles);

    }

    private void rotateIt()
    {
        float direc =0.5f -animator.GetFloat("direction");
        //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 60 * Time.deltaTime * direc, 0);
        transform.Rotate(Vector3.up, direc * 60 * Time.deltaTime);
    }


}
