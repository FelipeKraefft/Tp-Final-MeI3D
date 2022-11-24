using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public GameObject memoTest, perdiste;

    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 4;
        memoTest = GameObject.Find("MemoTest");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 64){
            timerText.text = "Time's Up!";
            memoTest.SetActive(false);
            perdiste.SetActive(true);
        }

        else if (Time.time > 4){
            timerText.text = TimerCountdown();
        }
        
        

    }

    public string TimerCountdown()
    {
        float timeLeft = 64f;
        timeLeft -= Time.time;
        string minutes = ((int)timeLeft / 60).ToString();
        string seconds = ((Mathf.Floor(timeLeft % 60)).ToString());

        if (StringToInt(seconds) > 9){
            seconds = seconds.Substring(0, 2);
            return minutes + ":" + seconds;
        }

        else{
            seconds = seconds.Substring(0, 1);
            return minutes + ":0" + seconds;
        }
    }

    //a function that convert a string to an int
    int StringToInt(string s)
    {
        int i = int.Parse(s);
        return i;
    }
    
}
