using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostTrigger : MonoBehaviour
{
    public GameObject ghost;
    public GameObject animationCamera;
    public DataSO data;
    GameObject player;
    bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player" && data.hasKey && !hasPlayed){
            animationCamera.SetActive(true);
            ghost.SetActive(true);
            Invoke("DeactivateCamera", 2.7f);
            
            Invoke("ghostCanMove", 2.7f);
            hasPlayed = true;
        }
    }

    void DeactivateCamera(){
        animationCamera.SetActive(false);
    }

    void ghostCanMove(){
        ghost.GetComponent<NavMeshAgent>().enabled = true;
    }
}
