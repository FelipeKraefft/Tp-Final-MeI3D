using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LucaSays : MonoBehaviour
{
    public GameObject UIManager;
    public Text Luca;
    public LightsManager lightsManager;
    public bool TalkedToLuca;
    bool talking;
    public Text instructions;
    public DialogsSO dialogsSO;
    [SerializeField] bool TalkedToLucaBefore;
    [SerializeField] int cont;
    

    string[] dialogs = { 
    "Hola, soy ... antes de nada podiras prender las luces de L1, que no se que paso que se apagaron todas las luces y no veo nada", 
    "Ya te dije que vayas a prender las luces primero",
    "Muy bien, ya que prendiste las luces!",
    "Perfecto, te recomiendo que te vayas lo antes posible, estan pasando cosas raras por aca", 
    "Para que te puedas ir necesitas la llave de la puerta de L1, para eso tenes que jugar conmigo ya que hace rato que me aburro mucho",
    "Queres jugar? Si o No?",
    "Perfecto, En esta mesa vas a encontrar un juego de memotest, tenes 2 minutos para encontrar todas las parejas, Suerte!",
    };   

    // Start is called before the first frame update
    void Start()
    {
        lightsManager = GameObject.Find("[LightsManager]").GetComponent<LightsManager>();
        TalkedToLuca = false;
        cont = 0;
        talking = false;

        dialogsSO.SetDialog(dialogs);
    }

    // Update is called once per frame
    void Update()
    {
        if (TalkedToLuca){
            instructions.gameObject.SetActive(true);
        }

        if (!TalkedToLuca){
            instructions.gameObject.SetActive(false);
        } 
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player" && !lightsManager.lucesEncendidas && !TalkedToLucaBefore){
            ActivarUI();
            Luca.text = dialogsSO.dialogs[0];
            dialogsSO.currentDialog++;
            TalkedToLucaBefore = true;
            cont++;
        }

        else if (col.gameObject.tag == "Player" && !lightsManager.lucesEncendidas && TalkedToLucaBefore){
            ActivarUI();
            TalkedToLucaBefore = true;
            Luca.text = dialogsSO.dialogs[1];
            cont++;
        }

        else if(col.gameObject.tag == "Player" && lightsManager.lucesEncendidas && cont == 0 && !TalkedToLucaBefore){
            ActivarUI();
            TalkedToLuca = true;
            Luca.text = dialogsSO.dialogs[2];
            dialogsSO.currentDialog = 2;
            talking = true;           
            TalkedToLucaBefore = true;
            cont++;
        }

        else if (col.gameObject.tag == "Player" && lightsManager.lucesEncendidas && cont > 0 && TalkedToLucaBefore){
            ActivarUI();
            TalkedToLuca = true;
            Luca.text = dialogsSO.dialogs[3];
            dialogsSO.currentDialog = 3;
            talking = true;
            cont++;
        }
    }

    void OnTriggerStay(Collider col){
        if (col.gameObject.tag == "Player" && talking && Input.GetKeyDown(KeyCode.Return)){
            dialogsSO.currentDialog++;
            Luca.text = dialogsSO.dialogs[dialogsSO.currentDialog];
        }

        else if (dialogsSO.currentDialog == 7){
            talking = false;
            //Hacer animacion de entrando al juego de memotest
        }
    }

    void ActivarUI(){
        UIManager.GetComponent<UIManager>().LucaSays.SetActive(true);
        Time.timeScale = 0;
    }
}
