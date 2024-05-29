using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public int indiceNivel;


    public void CambiarNivel(){
        SceneManager.LoadScene(indiceNivel);
    }
}
