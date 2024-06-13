using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class DatosJuego 
{
    public float posicionX;
    public float posicionY;
    public int scene;
    public List<double> mainMissions;
    public List<double> secondaryMissions;
    public int dinero;
}
