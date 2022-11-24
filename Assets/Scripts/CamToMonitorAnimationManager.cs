using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamToMonitorAnimationManager : MonoBehaviour
{
    public GameObject cam;
    Animator anim;
    public DataSO data;

    // Start is called before the first frame update
    void Start()
    {
        anim = cam.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.active && data.isFirstTime)
        {
            anim.SetBool("isFirstTime", true);
        }
        else if (cam.active)
        {
            anim.SetBool("isFirstTime", false);
        }
    }
}
