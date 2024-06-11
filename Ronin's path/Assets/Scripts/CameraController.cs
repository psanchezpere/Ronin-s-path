using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{

    private static CameraController Instance;
    private CinemachineVirtualCamera vcam;

    public Transform personajeTransform;
    
    private float tamañoCamara;
    private float alturaPantalla;
    // Start is called before the first frame update


    void Start()
    {
        if(personajeTransform == null && GameObject.Find("Personaje")!= null){
            personajeTransform = GameObject.Find("Personaje").GetComponent<Transform>();
        }
        tamañoCamara = Camera.main.orthographicSize;
        alturaPantalla = tamañoCamara * 2;
        
        if(GameObject.Find("Virtual Camera") != null){
            vcam = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
            vcam.Follow = personajeTransform;
        }
    }


}
