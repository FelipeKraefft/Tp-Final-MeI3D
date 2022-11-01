using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject start;
    public GameObject LucaSays;

    // Start is called before the first frame update
    void Start()
    {
        LucaSays.SetActive(false);
        start.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1;
            start.SetActive(false);
            LucaSays.SetActive(false);
        }
    }
    
}
