using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrarAlCastillo : MonoBehaviour
{

    private CambiarEscena cambiarEscena;

    private CuadroTexto puertaCastillo;


    // Start is called before the first frame update
    private void Start()
    {
        puertaCastillo = GameObject.Find("PuertaCastillo").GetComponent<CuadroTexto>();
        cambiarEscena = GameObject.Find("EntrarAlCastillo").GetComponent<CambiarEscena>();
    }

    // Update is called once per frame
    void Update()
    {
        if(puertaCastillo.checkInteraction()){
            cambiarEscena.CambiarNivel();
        }
    }
}
