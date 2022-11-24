using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPlayer : MonoBehaviour
{
    public static SingletonPlayer player;

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        DontDestroyOnLoad(gameObject);

        if (player == null) 
        {    
            player = this; 
        } 
        else 
        { 
            Destroy(gameObject);
        } 
        // If I'm the instance, don't destroy me.
    }
}