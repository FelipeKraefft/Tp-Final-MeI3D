using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPlayer : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
