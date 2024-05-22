using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{

    [SerializeField] private GameObject menuPausa;


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

    public bool IsOpen(){
        return menuPausa.activeInHierarchy;
    }
}
