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
    [SerializeField]bool talking;
    public DialogsSO dialogsSO;
    [SerializeField] bool TalkedToLucaBefore;
    [SerializeField] int cont;
    public Animator camAnim;

    Rigidbody rb;
    UIManager uiManager;
    public GameObject player, CamToMemo;

    string[] dialogs = { 
    "Hola, soy Luca antes de nada podiras prender las luces de L1, que no se que paso que se apagaron todas las luces y no veo nada", 
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
        uiManager = UIManager.GetComponent<UIManager>();
        rb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

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
        if (col.gameObject.tag == "Player" && !talking && Input.GetKeyDown(KeyCode.Return)){
            DesactivarUI();
        }

        if (col.gameObject.tag == "Player" && talking && Input.GetKeyDown(KeyCode.Return)){
            dialogsSO.currentDialog++;
            Luca.text = dialogsSO.dialogs[dialogsSO.currentDialog];
        }

        if (dialogsSO.currentDialog == 7){
            talking = false;
            DesactivarUI();
            GoToMiniGame();

        }
    }

    void OnTriggerExit(Collider col){
        if (col.gameObject.tag == "Player"){
            DesactivarUI();
        }
    }

    void ActivarUI(){
        uiManager.LucaSays.SetActive(true);
    }

    void DesactivarUI(){
        Time.timeScale = 1;
        uiManager.start.SetActive(false);
        uiManager.LucaSays.SetActive(false);
    }

    void GoToMiniGame(){
        //Hacer animacion de entrando al juego de memotest
        player.SetActive(false);
        CamToMemo.SetActive(true);
        Invoke("GoToSceneMemotest", 2f);
        Invoke("IntoPlayer", 2.5f);
    }

    void GoToSceneMemotest(){
        SceneManager.LoadScene("Memotest");
    }

    void IntoPlayer(){
        camAnim.SetBool("Entering", false);
        Invoke("EndAnimation", 1.5f);
        
    }

    void EndAnimation(){
        player.SetActive(true);
        CamToMemo.SetActive(false);
    }
}
