using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorAnimationManager : MonoBehaviour
{
    public DataSO data;
    public Animator doorAnim;
    public GameObject doorCanvas;


    // Start is called before the first frame update
    void Start()
    {
        doorCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && data.hasKey)
        {
            doorCanvas.SetActive(true);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && data.hasKey)
        {
            doorAnim.SetBool("Open", true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        doorCanvas.SetActive(false);
    }
}
