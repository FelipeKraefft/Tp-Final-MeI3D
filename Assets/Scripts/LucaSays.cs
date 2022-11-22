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
    public Text instructions;
    [SerializeField] bool TalkedToLucaBefore;
    [SerializeField] int cont;

    // Start is called before the first frame update
    void Start()
    {
        lightsManager = GameObject.Find("[LightsManager]").GetComponent<LightsManager>();
        TalkedToLuca = false;
        cont = 0;
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
            Luca.text = "¿Qué haces aca? Enciende las luces primero";
            TalkedToLucaBefore = true;
            cont++;
        }

        else if (col.gameObject.tag == "Player" && !lightsManager.lucesEncendidas && TalkedToLucaBefore){
            ActivarUI();
            TalkedToLucaBefore = true;
            Luca.text = "Ya te dije que vayas a prender las luces primero";
            cont++;
        }

        else if(col.gameObject.tag == "Player" && lightsManager.lucesEncendidas && cont == 0 && !TalkedToLucaBefore){
            ActivarUI();
            TalkedToLuca = true;
            Luca.text = "Holaa!  Escuche lo que paso, la contraseña que necesitas es -DaroNoEsta-";
            TalkedToLucaBefore = true;
            cont++;
        }

        else if (col.gameObject.tag == "Player" && lightsManager.lucesEncendidas && cont > 0 && TalkedToLucaBefore){
            ActivarUI();
            TalkedToLuca = true;
            Luca.text = "Bien hecho! Ya puedes entrar a la computadora, acordate de la contraseña -DaroNoEsta-";
            cont++;
        }

        if(Input.GetKeyDown(KeyCode.Return)){
            Time.timeScale = 1;
            UIManager.GetComponent<UIManager>().LucaSays.SetActive(false);
        }
    }

    void ActivarUI(){
        UIManager.GetComponent<UIManager>().LucaSays.SetActive(true);
        Time.timeScale = 0;
    }
}
