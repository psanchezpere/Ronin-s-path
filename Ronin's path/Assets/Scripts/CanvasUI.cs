using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{

    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject levelName;
    [SerializeField] private GameObject interfazGetasSaltoDoble;
    [SerializeField] private GameObject interfazFingirMuerte;
    [SerializeField] private CanvasGroup canvasLevelName;
    private DataController dataController;
    float secondsCounter=0;
    float secondsToCount=6;


    // Update is called once per frame
    public void UpdateLevelName()
    {
      secondsCounter += Time.deltaTime;
        if (secondsCounter >= secondsToCount){
            if(canvasLevelName.alpha>=0){
                canvasLevelName.alpha-=Time.deltaTime;
            }
        }else{
            levelName.SetActive(true);
            if(canvasLevelName.alpha<=1){
                canvasLevelName.alpha+=Time.deltaTime;
            }
        }
        
   }
    private void Start(){
        dataController = GameObject.Find("DataController").GetComponent<DataController>();
    }

    public void CloseGame(){
        Application.Quit();
    }

    public void OpenControls(){
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
    }

    public void ResumeGame(){
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
    }
    public void SaveGame(){
        dataController.SaveGame();
    }

    public bool IsOpen(){
        if(menuPausa != null){
            return menuPausa.activeInHierarchy;
        }
        return false;
    }

    public void OpenInterfazGetasSaltoDoble(){
        Time.timeScale = 0f;
        interfazGetasSaltoDoble.SetActive(true);
    }

    public void OpenInterfazFingirMuerte(){
        Time.timeScale = 0f;
        interfazFingirMuerte.SetActive(true);
    }
    
}
