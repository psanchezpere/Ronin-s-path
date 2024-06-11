using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dinero : MonoBehaviour
{

    private int dineroAcumulado;

    private TextMeshProUGUI textMesh;


    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = "両 " +dineroAcumulado.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Ponemos delante el simbolo del Ryō , moneda de oro japonesa de la época feudal
        textMesh.text = "両 " +dineroAcumulado.ToString();
    }

    public void SumarDinero(int dineroGanado){
        dineroAcumulado += dineroGanado;
    }

    public int TotalDinero(){
        return dineroAcumulado;
    }

}
