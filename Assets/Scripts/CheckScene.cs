using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScene : MonoBehaviour
{
    public DataSO data;
    public bool isScene1;
    // Start is called before the first frame update
    void Start()
    {
        data.isScene1 = isScene1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
