using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog")]
public class DialogsSO : ScriptableObject
{
    int currentDialog = 0;

    string[] dialogs = { 
    "Hola, soy ... antes de nada podiras prender las luces de L1, que no se que paso que se apagaron todas las luces y no veo nada", 
    "Ya te dije que vayas a prender las luces primero",
    "Perfecto, te recomiendo que te vayas lo antes posible, estan pasando cosas raras por aca", 
    "Para que te puedas ir necesitas la llave de la puerta de L1, para eso tenes que jugar conmigo ya que hace rato que me aburro mucho",
    "Queres jugar? Si o No?",
    "Perfecto, En esta mesa vas a encontrar un juego de memotest, tenes 2 minutos para encontrar todas las parejas, Suerte!",
    };    
}
