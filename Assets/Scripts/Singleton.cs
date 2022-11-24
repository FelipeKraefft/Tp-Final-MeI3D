using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public DataSO data;
    public static Singleton Instance;
    public GameObject player;

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        DontDestroyOnLoad(gameObject);

        if (Instance == null) 
        {    
            Instance = this; 
        } 
        else 
        { 
            Destroy(gameObject);
        } 
        // If I'm the instance, don't destroy me.
    }

    // Update is called once per frame
    void Update()
    {
        if(data.isScene1)
        {
            player.SetActive(true);
        }
    }
}
