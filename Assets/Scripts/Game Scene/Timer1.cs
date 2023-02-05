using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer1 : MonoBehaviour
{
    [SerializeField] private float startTime;

    public Tile_Counter tileCounter;
    public Return_Menu changeCanvas;

    public float currentTime;
    private bool timerStarted = false;

    // ref var for my TMP text component
    [SerializeField] private TMP_Text timerText;

    private void Start()
    {
        //resets the currentTime to the start time 
        currentTime = startTime;
        //displays the UI with the currentTime
        timerText.text = currentTime.ToString();
        // starts the time -- comment this out if you don't want to automagically start
        timerStarted = true;
    }

    private void Update()
    {
        if (timerStarted)
        {
            // subtracting the previous frame's duration
            currentTime -= Time.deltaTime;
            // logic current reached 0?
            if (currentTime <= 0)
            {
                timerStarted = false;
                tileCounter.GameOver();
                currentTime = 0;
                changeCanvas.changeCanvas();
            }
            timerText.text = "Time " + currentTime.ToString("f1");
        }
    }
}
