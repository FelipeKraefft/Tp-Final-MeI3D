using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsGhost : MonoBehaviour
{
    public GameObject ghostSusto;
    bool firstTime;

    // Start is called before the first frame update
    void Start()
    {
        firstTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(ghostSusto.active && firstTime){
            Invoke("DeactivateGhost", .3f);
        }
    }

    void DeactivateGhost(){
         ghostSusto.SetActive(false);
    }
}
