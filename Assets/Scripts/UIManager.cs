using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject start;
    public GameObject LucaSays;
    bool isStart = true;
    public Data data;

    // Start is called before the first frame update
    void Start()
    {
        if(data.isFirstTime){
            LucaSays.SetActive(false);
            start.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isStart && Input.GetKeyDown(KeyCode.Return))
        {
            start.SetActive(false);
            Time.timeScale = 1;
            isStart = false;
        }
    }
    
}
