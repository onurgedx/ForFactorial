using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartSmoothly : MonoBehaviour
{
    [SerializeField]
    private GameObject stickAs;

    public GameObject StickController;

    private float timeGoHome;

    private Vector3 beginPos;

    public float time2h;

    public Animator animator;


    // Start is called before the first frame update
    private void Start()
    {

        
    }

    // Update is called once per frame
    private void Update()
    {

        TimeToRes();
    }
    private float timeOfAni(float time, float min = 0, float max = 0.99f)
    {
        return Mathf.Clamp(time, min, max);
    }
    private void goStart()
    {
        time2h +=Time.deltaTime* RestrictSinSpeed();

        transform.localPosition = Vector3.Lerp(beginPos, Vector3.zero,time2h);
        transform.GetChild(1).rotation = Quaternion.Lerp(transform.GetChild(1).rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime);
        animator.SetFloat("time", timeOfAni(animator.GetFloat("time") - Time.deltaTime));
    }
    

    private void TimeToRes()
    {
    if(time2h >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           

        }
        else
        {goStart();

        }

    }

    private float RestrictSinSpeed()
    {
        timeGoUpdate();
        return Mathf.Clamp(Mathf.Sin(timeGoHome * Mathf.PI),0.15f,0.75f);
    }

    private void timeGoUpdate()
    {
        timeGoHome = 1 - (transform.localPosition.magnitude / beginPos.magnitude);

    }

    private void OnEnable()
    {
        timeGoHome = 0f;
        

        transform.parent = stickAs.transform;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        beginPos = transform.localPosition;
    }
}

