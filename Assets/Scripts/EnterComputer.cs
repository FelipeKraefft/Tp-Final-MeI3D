using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterComputer : MonoBehaviour
{
    public GameObject Camera;
    GameObject Player;
    LucaSays LucaSays;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        LucaSays = GameObject.Find("Luca").GetComponent<LucaSays>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && LucaSays.TalkedToLuca)
        {
            Player.SetActive(false);
            Camera.SetActive(true);
        }
    }
}
