using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Ghost : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public GameObject susto;
    public GameObject lucaWarning;
    public DataSO data;
    Animator anim;
    GameObject ghostTrigger;
    GameObject ghost;

    // Start is called before the first frame update
    void Start()
    {
        ghostTrigger = GameObject.Find("[GhostTrigger]");
        ghost = GameObject.Find("Ghost");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        try{
            agent.SetDestination(GetPlayer().position);
        }
        catch{
        }

        if(!ghostTrigger.GetComponent<GhostTrigger>().hasPlayed){
            //ghost.SetActive(false);
        }

        else if(ghostTrigger.GetComponent<GhostTrigger>().hasPlayed){
            ghost.SetActive(true);
        }

        if(ghost.GetComponent<NavMeshAgent>().enabled){
            anim.SetBool("isWalking", true);
        }

    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            susto.SetActive(true);
            lucaWarning.SetActive(false);
        }
    }

    //a function that get the player from dont destoy on load
    public Transform GetPlayer(){
        return GameObject.FindGameObjectWithTag("Player").transform;
    }

    
}
