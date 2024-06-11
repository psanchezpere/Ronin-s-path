using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirDelCastillo : MonoBehaviour
{

    private GameObject canvasSalir;
    private SceneController sceneController;

    // Start is called before the first frame update
    private void Start()
    {
        canvasSalir = GameObject.Find("CanvasSalir");
        sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canvasSalir.activeInHierarchy && Input.GetKeyDown(KeyCode.Return)){
            sceneController.ExitCastleMusashi();
        }
    }
    
}
