using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavePotentionFree : MonoBehaviour
{
    public Animator animator;

    public GameObject rocketman;

    [SerializeField]
    private GameObject rocketMancControl;
    
    [SerializeField]
    private GameObject parent_rocketman;

    [SerializeField]
    private CamToRocket cam2rock;


    public float power;

    // Update is called once per frame

    private void Start()
    {
        power = animator.GetFloat("time");

    }
    private void FixedUpdate()
    {
        float timeAni = animator.GetFloat("time");
        animator.SetFloat("time", timeAni-Time.deltaTime*3);
        
        if(timeAni<=0)
        { 
            setFree();

            this.enabled = false;  
        }


    }
   

    private void setFree()
    {
        
        rocketMancControl.GetComponent<AddForceOnEnable>().power = power;


        rocketMancControl.SetActive(true);

        rocketman.transform.parent = null;

        

        
        
        
        rocketman.GetComponent<Rigidbody>().useGravity = true;

       camMoving();
        

        gameObject.SetActive(false);

    }
    
    private void camMoving()
    {
        //  Camera.main.gameObject.GetComponent<CamToRocket>().enabled = true;
        cam2rock.enabled = true;
     
    }




    private void setUnFree()
    {
        
        rocketman.transform.parent = parent_rocketman.transform;
        rocketman.GetComponent<Rigidbody>().useGravity = false;
        
    }



}
