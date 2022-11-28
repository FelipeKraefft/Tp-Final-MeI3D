using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectCanvasOnSecondLoad : MonoBehaviour
{
    public GameObject LucaSays;
    public DataSO data;
    bool firstTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(data.isScene1 && firstTime){
            LucaSays.SetActive(true);
            firstTime = false;
        }
    }
}
