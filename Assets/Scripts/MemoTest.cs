using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MemoTest : MonoBehaviour
{
    public Texture[] tag;
    RawImage img;
    [SerializeField] bool firstClick;
    [SerializeField] GameObject[] pieces;
    [SerializeField] int[] randoms = new int[18];

    int cont;
    bool canCheck;
    bool canPress;
    public static bool allCorrect;
    Texture firstTexture, secondTexture;
    GameObject firstTag, secondTag;
    GameObject firstCorrectPiece, secondCorrectPiece;
    public DataSO data;

    // Start is called before the first frame update
    void Start()
    {
        cont = 0;
        firstClick = true;
        randoms = randomArray0to8();
        canPress = true;

        for (int i = 0; i < 18; i++)
        {
            //img = pieces[i].GetComponent<RawImage>();
            pieces[i].GetComponent<RawImage>().texture = tag[randoms[i]];
        }

    }

    // Update is called once per frame
    void Update()
    {
        allCorrect = CheckWin();
        if(allCorrect)
        {
            data.isFirstTime = false;
            data.hasKey = true;
            Invoke("WinGame", 1f);
        }
    }

    public void WinGame()
    {
        SceneManager.LoadScene(0);
    }


    int[] randomArray0to8() {
        int[] randomArray = new int[18];
        int[] repeated_numbers = new int[9];
        for (int i = 0; i < 18; i++) {
            int random = Random.Range(0, 9);
            if (repeated_numbers[random] < 2) {
                randomArray[i] = random;
                repeated_numbers[random]++;
            }
            else {
                i--;
            }
        }
        return randomArray;
    }


    public void PieceClick(){
        if(canPress){
            GameObject btn = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        
            if(firstClick){
                firstTag = btn.transform.GetChild(1).gameObject;
                firstTag.SetActive(true);

                firstTexture = firstTag.GetComponent<RawImage>().texture;
                firstClick = false;
                canCheck = false;
            }

            else if(!firstClick){
                secondTag = btn.transform.GetChild(1).gameObject;
                secondTag.SetActive(true);

                if(firstTag == secondTag){
                    return;
                }
                secondTexture = secondTag.GetComponent<RawImage>().texture;

                firstClick = true;
                canPress = false;
                Invoke("HideTags", 1f);
                Invoke("canPressToTrue", 1f);
                canCheck = true;
            }
            

            if (firstTexture == secondTexture && canCheck) {
                firstClick = true;
                Invoke("HidePieces", .5f);
                canCheck = false;
                cont++;
            }   
            
        }
        
    }

    
    

    void HideTags() {
        firstTag.SetActive(false);
        secondTag.SetActive(false);
    }

    void canPressToTrue(){
        canPress = true;
    }

    void HidePieces(){
        firstTag.transform.parent.gameObject.SetActive(false);
        secondTag.transform.parent.gameObject.SetActive(false);
    }

    bool CheckWin(){
        return cont == 9;
    }
}