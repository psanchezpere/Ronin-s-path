using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CuadroTextoPatrulla : MonoBehaviour
{

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)]private string [] dialogueLines; 

    [SerializeField] private float typingTime = 0.01f;

    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex = 0;
    private CharacterController charController;

    void Start(){
        charController = GameObject.Find("Personaje").GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isPlayerInRange){
            if((dialogueText.text != dialogueLines[lineIndex])){
                if (!didDialogueStart){
                    StartDialogue();
                }else if (dialogueText.text == dialogueLines[lineIndex]){
                    NextDialogueLine();
                }
            }else if(Input.GetKeyDown(KeyCode.Return)){
                Time.timeScale = 1f;
                charController.MoveCharacter(new Vector3(-169,90,0));
            }
        }else {
            didDialogueStart = false;
            dialogueText.text = string.Empty;
            dialoguePanel.SetActive(false);
            lineIndex = 0;
        }
        
    }

    private IEnumerator ShowLine(){
        dialogueText.text = string.Empty;

        foreach(char ch in dialogueLines[lineIndex]){
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }


    private void StartDialogue(){
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine(){
        lineIndex++;
        if(lineIndex < dialogueLines.Length){
            StartCoroutine(ShowLine());
        }else{
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
        }
    }

    private void OnTriggerEnter2D (Collider2D collision){
        if(collision.gameObject.CompareTag("Player") && charController.IsNotDead()){
            Time.timeScale = 0f;
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit2D (Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            isPlayerInRange = false;
        }
    }

    private bool checkInteraction (){
        if(dialoguePanel.activeInHierarchy && Input.GetKeyDown(KeyCode.Return)){
            return true;
        }
        return false;
    }
    
}
