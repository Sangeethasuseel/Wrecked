using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public Text timeCounter;
    public int gameTime=120;
    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;

    private void Awake()
    {
        instance=this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        timeCounter.text = "Time Left: 02:00";
        timerGoing = false;
        
    }
    public void beginTimer()
    {
        timerGoing = true;
        elapsedTime = gameTime;
        StartCoroutine(UpdateTimer());

    }

    public void EndTimer()
    {
        timerGoing = false;
    }

  
   private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime -= Time.deltaTime;
            if (elapsedTime < 0) FindObjectOfType<GameManager>().EndGame();
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time Left: " + timePlaying.ToString("mm':'ss");
            timeCounter.text = timePlayingStr;
            yield return null;

        }
    }
}
