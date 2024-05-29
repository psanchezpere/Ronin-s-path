using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirDelCastillo : MonoBehaviour
{

    private CambiarEscena cambiarEscena;

    private GameObject canvasSalir;

    // Start is called before the first frame update
    private void Start()
    {
        canvasSalir = GameObject.Find("CanvasSalir");
        cambiarEscena = GameObject.Find("CambiarEscena").GetComponent<CambiarEscena>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canvasSalir.activeInHierarchy && Input.GetKeyDown(KeyCode.Space)){
            cambiarEscena.CambiarNivel();
        }
    }
}
