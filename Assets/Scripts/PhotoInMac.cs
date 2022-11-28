using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoInMac : MonoBehaviour
{
    public GameObject photo;

    // Start is called before the first frame update
    void Start()
    {
        RenderImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RenderImage(){
        photo.SetActive(true);
        Invoke("UnRenderImage", .7f);
    }

    void UnRenderImage(){
        photo.SetActive(false);
        Invoke("RenderImage", 5f);
    }
}
