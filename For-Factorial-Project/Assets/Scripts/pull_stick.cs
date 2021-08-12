using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pull_stick : MonoBehaviour
{

    public Animator animator;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("time", animator.GetFloat("time")+Time.deltaTime/20f);
        
       

    }

    


    


}
