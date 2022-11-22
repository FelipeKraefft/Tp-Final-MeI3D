using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog")]
public class DialogsSO : ScriptableObject
{
    public string[] dialogs;
    public int currentDialog = 0;

    public void SetDialog(string[] dialog)
    {
        this.dialogs = dialog;
    } 
}
