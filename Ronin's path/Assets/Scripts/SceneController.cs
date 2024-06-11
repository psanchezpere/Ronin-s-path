using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    private static SceneController Instance;
    private CharacterController characterController;

    private CuadroTexto puertaCastillo;
    private Vector3 position;
    private Scene scene;
    private StoryController storyController;


    private void Awake(){
        if (SceneController.Instance ==null)
        {
            SceneController.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else{
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    private void Start()
    {
        characterController = GameObject.Find("Personaje").GetComponent<CharacterController>();
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();
        position = new Vector3(characterController.GetActualPositionX(),characterController.GetActualPositionY(),0);
        if(scene.buildIndex == 3){
            if(position.x < -467){
                SceneManager.LoadScene(4);
                Vector3 vector = new Vector3(-30,90,0);
                characterController.MoveCharacter(vector);
            }
        }
        else if(scene.buildIndex == 4){
            
            if(position.x < -460){
                SceneManager.LoadScene(0);
            }

            if(position.x > -7 && position.y <100){
                SceneManager.LoadScene(3);
                Vector3 vector = new Vector3(-452,114,0);
                characterController.MoveCharacter(vector);
            }
        }
    }

    public void ExitCastleMusashi(){
        SceneManager.LoadScene(3);
        Vector3 vector = new Vector3(449,120,0);
        characterController.MoveCharacter(vector);
    }

    public void NewGame(){
        SceneManager.LoadScene(1);
    }

    public int GetActualScene(){
        return scene.buildIndex;
    }

}
