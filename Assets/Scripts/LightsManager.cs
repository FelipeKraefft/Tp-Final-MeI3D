using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightsManager : MonoBehaviour
{
    public GameObject Lights;
    public GameObject[] LuzMonitores;
    public Canvas canvas;
    public Text instrucciones;
    public DataSO data;
    public GameObject ghostSusto;
    bool firstTime;

    public bool lucesEncendidas;

    // Start is called before the first frame update
    void Start()
    {
        LuzMonitores = GameObject.FindGameObjectsWithTag("LuzMonitor");
        firstTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > 2 && Time.time < 3 && data.isFirstTime){
            Lights.SetActive(false);
            foreach(GameObject monitor in LuzMonitores){
                monitor.SetActive(false);
            }
            canvas.enabled = true;
        }

        if(Lights.active){
            instrucciones.enabled = false;
            lucesEncendidas = true;
        }
        else{
            instrucciones.enabled = true;
            lucesEncendidas = false;
        }

        if(lucesEncendidas && Time.time > 3 && firstTime){
            ghostSusto.SetActive(true);
            firstTime = false;
        }
    }
    
}
