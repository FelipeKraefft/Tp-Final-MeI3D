using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Data")]
public class DataSO : ScriptableObject
{
    public bool isFirstTime = true;
    public bool isScene1 = true; 
    public bool hasKey = false;
}
