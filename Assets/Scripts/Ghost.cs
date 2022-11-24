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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try{
            agent.SetDestination(target.position);
        }
        catch{
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            susto.SetActive(true);
        }
    }
}
