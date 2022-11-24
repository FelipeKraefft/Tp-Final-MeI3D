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
        memoTest = GameObject.Find("MemoTest");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        if (Time.timeSinceLevelLoad > 64){
            timerText.text = "Time's Up!";
            memoTest.SetActive(false);
            perdiste.SetActive(true);
        }

        else if (Time.timeSinceLevelLoad > 4){
            timerText.text = TimerCountdown();
        }
        
        

    }

    public string TimerCountdown()
    {
        float timeLeft = 64f;
        timeLeft -= Time.timeSinceLevelLoad;
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

    void fixTimer()
    {
        Time.timeScale = 1;
    }
    
}
