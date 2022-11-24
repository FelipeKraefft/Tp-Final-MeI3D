using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamToMonitorAnimationManager : MonoBehaviour
{
    public GameObject cam;
    Animator anim;
    public Data data;

    // Start is called before the first frame update
    void Start()
    {
        anim = cam.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (data.isFirstTime){
            anim.SetBool("Entering", true);
        }
        else{
            anim.SetBool("Entering", false);
        }
    }
}
