using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RecorderScore : MonoBehaviour
{
    public GameObject RocketMan;

    public Text Score;

    public Text MaxScore;

    private int RecordedScore;

    private void Start()
    {
        
        RecordedScore = PlayerPrefs.GetInt("Score",0);
        ShowMaxScore();
    }

    // Update is called once per frame
    private void Update()
    {

        UpDateScoreText();


        CheckScoreToCompare();

    }

    private void CheckScoreToCompare()
    {
        
        
      if( System.Convert.ToInt32(Score.text)>RecordedScore)
        {
            RefreshMaxScore();

        }
               
    }

    private void RefreshMaxScore()
    {
        
        
        RecordedScore = System.Convert.ToInt32(Score.text);
        ShowMaxScore();
        RecordMaxScore();
    }
    
    private void ShowMaxScore()
    {MaxScore.text = RecordedScore.ToString();
        
    }
    private void RecordMaxScore()
    {
        PlayerPrefs.SetInt("Score", RecordedScore);
    }

    private void UpDateScoreText()
    {
         

        

        Score.text = ((int)CalculateDistance()).ToString();

    }

    //uzaklik mesafesini veriyor
    private float CalculateDistance()
    {
        
       

        return AbsoluteDistance();


    }


    //pos farkini aliyor
    private Vector3 DistanceOfPosV3()
    {
        return  Vector3.Scale((RocketMan.transform.position - transform.position),new Vector3(1,0,1));
        
    }




    // pos farkinin buyuklugunu alýyor
    private float magnitudeOfV3Distance()
    {
        return DistanceOfPosV3().magnitude;
    }



    // Mutlak degerini donduruyor
    private float AbsoluteDistance()
    {
        return Mathf.Abs(magnitudeOfV3Distance());
    }
    
    







}
