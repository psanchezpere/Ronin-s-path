using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dinero : MonoBehaviour
{

    private float dineroAcumulado;

    private TextMeshProUGUI textMesh;


    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        dineroAcumulado += Time.deltaTime;
        // Ponemos delante el simbolo del Ryō , moneda de oro japonesa de la época feudal
        textMesh.text = "両 " +dineroAcumulado.ToString("0");
    }

    public void SumarDinero(float dineroGanado){
        dineroAcumulado += dineroGanado;
    }

}
