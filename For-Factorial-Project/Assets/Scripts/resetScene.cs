using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class resetScene : MonoBehaviour
{
    

    public void reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
    }

}
