using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LucaSays : MonoBehaviour
{
    public GameObject UIManager;
    public Text Luca;
    public LightsManager lightsManager;
    public bool TalkedToLuca;
    bool talking;
    public DialogsSO dialogsSO;
    public GameObject indicaciones;
    public GameObject camToTable;
    bool isPlayerPlaying;
    [SerializeField] bool TalkedToLucaBefore;
    [SerializeField] int cont;
    public DataSO data;
    

    string[] dialogs = { 
    "Hola, soy Luca! antes de nada podrias prender las luces de L1, que no se que paso que se apagaron todas las luces y no veo nada", 
    "Ya te dije que vayas a prender las luces primero",
    "Muy bien, ya que prendiste las luces!",

    "Perfecto, te recomiendo que te vayas lo antes posible, estan pasando cosas raras por aca", 
    "Para que te puedas ir necesitas la llave de la puerta de L1, para eso tenes que jugar conmigo ya que hace rato que me aburro mucho",
    "Queres jugar? Si o No?",
    "En esta mesa vas a encontrar un juego de memotest, tenes 1 minuto para encontrar todas las parejas, Suerte!",

    "Muy bien, ya encontraste todas las parejas, ahora tenes que ir a la puerta de L1 y usar la llave que te di",
    "Ya sabes que tenes que ir a la puerta de L1 y usar la llave que te di",
    };   

    // Start is called before the first frame update
    void Start()
    {
        lightsManager = GameObject.Find("[LightsManager]").GetComponent<LightsManager>();
        TalkedToLuca = false;
        cont = 0;
        talking = false;

        dialogsSO.SetDialog(dialogs);
        isPlayerPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col){

        ActivarUI();
        
        if (data.isFirstTime){
            if(col.gameObject.tag == "Player" && !lightsManager.lucesEncendidas && !TalkedToLucaBefore){
            dialogsSO.currentDialog = 0;
            TalkedToLucaBefore = true;
            cont++;
            }

            else if (col.gameObject.tag == "Player" && !lightsManager.lucesEncendidas && TalkedToLucaBefore){
                dialogsSO.currentDialog = 1;
                TalkedToLucaBefore = true;
                cont++;
            }

            else if(col.gameObject.tag == "Player" && lightsManager.lucesEncendidas && cont == 0 && !TalkedToLucaBefore){
                TalkedToLuca = true;
                dialogsSO.currentDialog = 2;
                talking = true;           
                TalkedToLucaBefore = true;
                cont++;
            }

            else if (col.gameObject.tag == "Player" && lightsManager.lucesEncendidas && cont > 0 && TalkedToLucaBefore && !isPlayerPlaying){
                TalkedToLuca = true;
                dialogsSO.currentDialog = 3;
                talking = true;
            }
        }
        

        if(!data.isFirstTime && col.gameObject.tag == "Player" && Luca.text == dialogsSO.dialogs[7]){
            dialogsSO.currentDialog = 7;
            data.hasKey = true;
        }
        else if (!data.isFirstTime && col.gameObject.tag == "Player" && Luca.text == dialogsSO.dialogs[8]){
            dialogsSO.currentDialog = 8;
        }
        Luca.text = dialogsSO.dialogs[dialogsSO.currentDialog];
    }


    void OnTriggerStay(Collider col){
        if (dialogsSO.currentDialog == 7 && data.isFirstTime && Input.GetKeyDown(KeyCode.Return)){ //Check for scene change
            talking = false;
            camToTable.SetActive(true);
            isPlayerPlaying = true;
            DesactivarUI();
            Invoke("ChangeToSceneMemoTest", 1.6f);
        }
        
        if (col.gameObject.tag == "Player" && talking && Input.GetKeyDown(KeyCode.Return)){
            dialogsSO.currentDialog++;
        }

        if (!talking && Input.GetKeyDown(KeyCode.Return) && col.gameObject.tag == "Player"){
            DesactivarUI();
        }

        Luca.text = dialogsSO.dialogs[dialogsSO.currentDialog];

        if (!data.isFirstTime){
            data.hasKey = true;
        }

    }


    void OnTriggerExit(Collider col){
        if (col.gameObject.tag == "Player"){
            DesactivarUI();
            TalkedToLuca = true;
        }
    }


    void ActivarUI(){
        UIManager.GetComponent<UIManager>().LucaSays.SetActive(true);
    }

    void DesactivarUI(){
        UIManager.GetComponent<UIManager>().LucaSays.SetActive(false);
    }

    void ChangeToSceneMemoTest(){
        SceneManager.LoadScene("MemoTest");
    }
}
