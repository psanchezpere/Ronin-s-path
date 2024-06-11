using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{

    private DataController dataController;
    private SceneController sceneController;
    public GameObject personaje;
    public GameObject scene;
    public GameObject story;
    private int sceneToLoad;

    public void NewGame(){
        ActiveCommonGameObjects();
        sceneController = scene.GetComponent<SceneController>();
        sceneController.NewGame();
    }
    public void LoadGame(){
        ActiveCommonGameObjects();
        dataController = GameObject.Find("DataController").GetComponent<DataController>();
        sceneToLoad = dataController.LoadGame();
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Exit(){
        Application.Quit();
    }

    private void ActiveCommonGameObjects(){
        personaje.SetActive(true);
        scene.SetActive(true);
        story.SetActive(true);
    }
}
