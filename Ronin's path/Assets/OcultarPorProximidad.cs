using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OcultarPorProximidad : MonoBehaviour
{

    private bool isPlayerInRange;

    [SerializeField] private CanvasGroup canvasFachada;
    void Update()
    {
        
        if (isPlayerInRange){
            canvasFachada.alpha-=Time.deltaTime;      
        }else {
            canvasFachada.alpha+=Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D (Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit2D (Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            isPlayerInRange = false;
        }
    }
    
}
