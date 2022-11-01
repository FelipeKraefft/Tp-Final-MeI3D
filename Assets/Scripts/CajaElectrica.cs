using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CajaElectrica : MonoBehaviour
{
    public Canvas canvas;

    public GameObject[] LuzMonitores;
    public GameObject Luces;

    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
        LuzMonitores = GameObject.FindGameObjectsWithTag("LuzMonitor");
        Luces = GameObject.FindGameObjectWithTag("Luces");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            canvas.enabled = true;
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){
            canvas.enabled = false;
        }
    }

    private void OnTriggerStay(Collider col) {
        if(col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E)){
            foreach(GameObject monitor in LuzMonitores){
                monitor.SetActive(true);
            }
            Luces.SetActive(true);
        }
    }
}
