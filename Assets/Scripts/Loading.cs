using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Text txtloading;

    GameObject loadingScreen;
    public GameObject passScreen;

    [SerializeField] Text persentaje;
    [SerializeField] GameObject[] loading;

    float startTime;
    float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        startTime = Time.time;

        loadingScreen = GameObject.Find("LoadingScreen");

        foreach (GameObject load in loading)
        {
            load.SetActive(false);
        }
        persentaje.text = "0%";
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = Time.time - startTime;

        if(Mathf.Floor(elapsedTime) % 3 == 0)
        {
            txtloading.text = "Loading.";
        }
        else if(Mathf.Floor(elapsedTime) % 3 == 1)
        {
            txtloading.text = "Loading..";
        }
        else if(Mathf.Floor(elapsedTime) % 3 == 2)
        {
            txtloading.text = "Loading...";
        }


        if (Mathf.Floor(elapsedTime) % 17 == 2){
            loading[0].SetActive(true);
            persentaje.text = "7%";
        }

        else if (Mathf.Floor(elapsedTime) % 17 == 4){
            loading[1].SetActive(true);
            loading[2].SetActive(true);
            loading[3].SetActive(true);
            persentaje.text = "36%";
        }

        else if (Mathf.Floor(elapsedTime) % 17 == 5){
            loading[4].SetActive(true);
            persentaje.text = "50%";
        }

        else if (Mathf.Floor(elapsedTime) % 17 == 8){
            loading[5].SetActive(true);
            loading[6].SetActive(true);
            persentaje.text = "85%";
        }

        else if (Mathf.Floor(elapsedTime) % 17 == 9){
            loading[7].SetActive(true);
            loading[8].SetActive(true);
            persentaje.text = "99%";
        }

        else if (Mathf.Floor(elapsedTime) % 17 == 14){
            loading[9].SetActive(true);
            persentaje.text = "100%";
        }

        else if (Mathf.Floor(elapsedTime) % 17 == 16){
            loadingScreen.SetActive(false);
            passScreen.SetActive(true);
        }
    }
}
