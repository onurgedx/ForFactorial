using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SoundController : MonoBehaviour
{

    public FallAlways fall;
    public FallWithGlider fallGlider;

    public AudioSource AuSourceRocket;

    public AudioClip Wind;
    public AudioClip WindLoop;

    public float[] MaxMinPitch= new float[2];// 1.5f , 3.0f


    //Stick Sound
    public Animator aniStickSound;

    public AudioSource AudioSourceStick;
    private float RecordStickAnitime=0f;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        CheckWhichOnline();
        StickSoundMain();



    }


    private void StickSoundMain()
    {
        if(isStickCreak())
        {
            if (isOfflinePlayStick())
            {
                CreakStickPlay();
               

            }
             RefreshRecordStickTime();
        }
        else
        {
            StopTheStickMusic();

        }
        

    }
    private void StopTheStickMusic()
    {
        AudioSourceStick.Pause();
       
    
    }

    private bool isStickCreak()
    {
        AudioSourceStick.volume = aniStickSound.GetFloat("time");
        return RecordStickAnitime != aniStickSound.GetFloat("time");
    }

    private bool isOfflinePlayStick()
    {
        return !AudioSourceStick.isPlaying;
    }
    private void CreakStickPlay()
    {
        AudioSourceStick.Play();
    }
    private void RefreshRecordStickTime()
    {
        RecordStickAnitime = Mathf.Lerp(RecordStickAnitime, aniStickSound.GetFloat("time"),0.5f);
    }


    private void CheckWhichOnline()
    {
        if(isFallOnline())
        {

            PlayAccordingState(Wind, MaxMinPitch[1]);

        }
        else if(isFallGliderOnline())
        {
            PlayAccordingState(Wind, MaxMinPitch[0]);
        }
        

    }
    private void PlayAccordingState(AudioClip ac,float pit)
    { 
        
      

        AuSourceRocket.clip =ac;
        PlayIfNot();

        AuSourceRocket.pitch = Mathf.Lerp(AuSourceRocket.pitch, pit, 0.1f);


    }
    private void PlayIfNot()
    {
        if (!AuSourceRocket.isPlaying)
        {

            AuSourceRocket.Play();

        }

    }

    private bool isFallOnline()
    {
        return fall.enabled;
    }

    private bool isFallGliderOnline()
    {
        return fallGlider.enabled;
    }





}
