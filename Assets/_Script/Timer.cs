using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int countDownStartValue;
    public GameObject GameoverPanel;
    public GameObject TimerText;

    AudioSource audioSource;

    public bool stopTimer;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        countDownTimer();
    }

    void countDownTimer() {

        if (stopTimer) return;

        if (countDownStartValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            GetComponent<Text>().text = "Time " + spanTime.Minutes + " : " + spanTime.Seconds;
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
            
            if(countDownStartValue<10)
            {
                audioSource.Play();
                GetComponent<Animator>().SetBool("isTimeAlmostEnd", true);
            }
        }
        else
        {
             GameoverPanel.active=true;
             TimerText.active=false;
        }
        
    }

}
