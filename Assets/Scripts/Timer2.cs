using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer2 : GameBehaviour
{
    public float timeValue = 30;
    public TMP_Text timeText;
    float currentTime;

    void Update()
    {
       //Checking if there is still time remaining
       if (timeValue > 0)
       {
        //Count down time every frame
        timeValue -= Time.deltaTime;
       } 
       //If there is no time remaining
       else timeValue = 0;

       DisplayTime(timeValue);
    }

    //Displays time in the UI
    void DisplayTime(float timeToDisplay)
    {
        //Check to see the timer is below zero and lock it if it's not
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        //Displaying the time on the UI
        timeText.text = timeToDisplay.ToString("F2"); //F stands for float + 2 decimals
        
        //float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        //float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        //timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        IncrementTimer(5);
    }*/
    
    /*/// <summary>
    /// Increment our timer
    /// </summary>
    /// <param name="_increment">The amount to increment our timer</param>
    public void IncrementTimer(float _increment)
    {
        currentTime += 5;
    }*/

    
}
