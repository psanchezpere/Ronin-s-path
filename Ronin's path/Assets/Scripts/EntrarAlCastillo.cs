using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EntrarAlCastillo : MonoBehaviour
{
    private CuadroTexto puertaCastillo;


    // Start is called before the first frame update
    private void Start()
    {
        puertaCastillo = GameObject.Find("PuertaCastillo").GetComponent<CuadroTexto>();
    }

    // Update is called once per frame
    void Update()
    {
        if(puertaCastillo.checkInteraction()){
            SceneManager.LoadScene(2);
        }
    }
}
