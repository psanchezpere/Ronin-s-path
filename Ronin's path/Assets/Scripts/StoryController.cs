using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{


    private List<double> mainMissions = new List<double>();
    private List<double> secondaryMissions = new List<double>();
    private Dinero dinero;

    //Pueblo Kanazawa
    private BaulController baulDobleSalto;
    private CuadroTexto baulDobleSalto_CuadroTexto;
    private BaulController baulCastillo;
    private CuadroTexto baulCastillo_CuadroTexto;
    private CanvasUI canvasUI;
    
    // Start is called before the first frame update
    void Start()
    {
        canvasUI = GameObject.Find("CanvasUI").GetComponent<CanvasUI>();
        baulDobleSalto = GameObject.Find("Baul_DobleSalto").GetComponent<BaulController>();
        baulDobleSalto_CuadroTexto = GameObject.Find("Baul_DobleSalto").GetComponent<CuadroTexto>();
        baulCastillo = GameObject.Find("BaulCastillo").GetComponent<BaulController>();
        baulCastillo_CuadroTexto = GameObject.Find("BaulCastillo").GetComponent<CuadroTexto>();
        dinero = GameObject.Find("Dinero").GetComponent<Dinero>();

    }

    // Update is called once per frame
    void Update()
    {
        updateMainMissions();
        updateSecondaryMissions();
    }


    private void updateMainMissions(){
        if(baulDobleSalto_CuadroTexto.checkInteraction()){
            mainMissions.Add(1);
            baulDobleSalto.OpenBaul();
            canvasUI.OpenInterfazGetasSaltoDoble();
        }
    }

    private void updateSecondaryMissions(){
        if(baulCastillo_CuadroTexto.checkInteraction() && !secondaryMissions.Contains(1.1)){
            dinero.SumarDinero(2000);
            secondaryMissions.Add(1.1);
            baulCastillo.OpenBaul();
        }
    }

    public bool checkMainMission(float mission){
        if(mainMissions.Contains(mission)){
            return true;
        }
        return false;   
    }
    public bool checkSecondaryMission(float mission){
        if(secondaryMissions.Contains(mission)){
            return true;
        }
        return false;
    }

}
