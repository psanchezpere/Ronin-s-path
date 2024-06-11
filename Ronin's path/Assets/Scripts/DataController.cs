using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataController : MonoBehaviour
{

    private static DataController Instance;
    public CharacterController characterController;
    public StoryController storyController;
    public SceneController sceneController;
    private  string archivoDeGuardado;
    public DatosJuego datosJuego = new DatosJuego();
    private void Awake()
    {
        archivoDeGuardado = Application.dataPath + "/datosJuego.json";
        if (DataController.Instance ==null)
        {
            DataController.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    public int LoadGame(){
        LoadGameObjects();
        if(File.Exists(archivoDeGuardado)){
            string contenido = File.ReadAllText(archivoDeGuardado);
            datosJuego = JsonUtility.FromJson<DatosJuego>(contenido);
            characterController = GameObject.Find("Personaje").GetComponent<CharacterController>();
            characterController.MoveCharacter(new Vector3(datosJuego.posicionX, datosJuego.posicionY,0));
            storyController.Initialize(datosJuego);
            return datosJuego.scene;
        }else{
            Debug.Log("El archivo no existe");
            return 0;
        }
    }

    public void SaveGame(){
        LoadGameObjects();
        DatosJuego nuevosDatos = new DatosJuego(){
            posicionX = characterController.GetActualPositionX(),
            posicionY = characterController.GetActualPositionY(),
            scene = sceneController.GetActualScene(),
            mainMissions = storyController.GetMainMissions(),
            secondaryMissions = storyController.GetSecondaryMissions()
        };

        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);
        File.WriteAllText(archivoDeGuardado, cadenaJSON);

        Debug.Log("Archivo guardado");
    }

    public bool CheckGameSaved (){
        return File.Exists(archivoDeGuardado);
    }


    private void LoadGameObjects(){
        characterController = GameObject.Find("Personaje").GetComponent<CharacterController>();
        storyController = GameObject.Find("StoryController").GetComponent<StoryController>();
        sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
    }
}
