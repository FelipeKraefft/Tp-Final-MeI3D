using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPassword : MonoBehaviour
{
    public Text pass;
    public GameObject Incorrect;
    public GameObject Correct;

    public GameObject PassScreen;
    public GameObject MiniGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Check()
    {
        if (pass.text == "DaroNoEsta")
        {
            Incorrect.SetActive(false);
            Correct.SetActive(true);
            Invoke("ChangeScreen", 2);
        }
        else{
            pass.text = "";
            Incorrect.SetActive(true);
        }
    }

    void ChangeScreen()
    {
        PassScreen.SetActive(false);
        MiniGame.SetActive(true);
    }
}
