using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallaControles : MonoBehaviour
{

    [SerializeField] private GameObject pantallaControles;


    public void CerrarControles(){
        Time.timeScale = 1f;
        pantallaControles.SetActive(false);
    }

    public void AbrirControles(){
        Time.timeScale = 0f;
        pantallaControles.SetActive(true);
    }

    public bool IsOpen(){
        return pantallaControles.activeInHierarchy;
    }
}
