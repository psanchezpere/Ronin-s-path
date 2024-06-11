using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{

    public static StoryController Instance;
    private List<double> mainMissions = new List<double>();
    private List<double> secondaryMissions = new List<double>();
    private Dinero dinero;

    //Pueblo Kanazawa
    private BaulController baulDobleSalto;
    private CuadroTexto baulDobleSalto_CuadroTexto;
    private BaulController baulCastillo;
    private CuadroTexto baulCastillo_CuadroTexto;

    //Bosque Aokigahara
    private BaulController baulBosqueDinero;
    private CuadroTexto baulBosqueDinero_CuadroTexto;
    private BaulController baulFingirMuerte;
    private CuadroTexto baulFingirMuerte_CuadroTexto;

    //Común
    private CanvasUI canvasUI;
    
    private int dineroNivelAnterior = 0;

    private void Awake(){
        if (StoryController.Instance ==null)
        {
            StoryController.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    bool CheckGameObject(string name){
        if(GameObject.Find(name)!= null){
            return true;
        }else{
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMainMissions();
        UpdateSecondaryMissions();

        // Si es nulo quiere decir que se ha cambiado de escena
        if (canvasUI == null && GameObject.Find("CanvasUI") != null){
            canvasUI = GameObject.Find("CanvasUI").GetComponent<CanvasUI>();
            dinero = GameObject.Find("Dinero").GetComponent<Dinero>();
            dinero.SumarDinero(dineroNivelAnterior);
            // Pantalla pueblo Kanazawa
            if(CheckGameObject("Baul_DobleSalto")){
                baulDobleSalto = GameObject.Find("Baul_DobleSalto").GetComponent<BaulController>();
                baulDobleSalto_CuadroTexto = GameObject.Find("Baul_DobleSalto").GetComponent<CuadroTexto>();
            }
            if(CheckGameObject("Baul_FingirMuerte")){
                baulFingirMuerte = GameObject.Find("Baul_FingirMuerte").GetComponent<BaulController>();
                baulFingirMuerte_CuadroTexto = GameObject.Find("Baul_FingirMuerte").GetComponent<CuadroTexto>();
            }
            if(CheckGameObject("BaulCastillo")){
                baulCastillo = GameObject.Find("BaulCastillo").GetComponent<BaulController>();
                baulCastillo_CuadroTexto = GameObject.Find("BaulCastillo").GetComponent<CuadroTexto>();
            }
            if(CheckGameObject("BaulBosqueDinero")){
                baulBosqueDinero = GameObject.Find("BaulBosqueDinero").GetComponent<BaulController>();
                baulBosqueDinero_CuadroTexto = GameObject.Find("BaulBosqueDinero").GetComponent<CuadroTexto>();
            }
            dineroNivelAnterior = dinero.TotalDinero();
        }
    }


    private void UpdateMainMissions(){
        if(baulDobleSalto_CuadroTexto!= null && baulDobleSalto_CuadroTexto.checkInteraction()&& !mainMissions.Contains(1)){
            mainMissions.Add(1);
            baulDobleSalto.OpenBaul();
            canvasUI.OpenInterfazGetasSaltoDoble();
        }
        if(baulFingirMuerte_CuadroTexto!= null && baulFingirMuerte_CuadroTexto.checkInteraction()&& !mainMissions.Contains(2)){
            mainMissions.Add(2);
            baulFingirMuerte.OpenBaul();
            canvasUI.OpenInterfazFingirMuerte();
        }
    }

    private void UpdateSecondaryMissions(){
        if(baulCastillo_CuadroTexto != null && baulCastillo_CuadroTexto.checkInteraction() 
        && !secondaryMissions.Contains(1.1)){
            dinero.SumarDinero(2000);
            secondaryMissions.Add(1.1);
            baulCastillo.OpenBaul();
        }
        if(baulBosqueDinero_CuadroTexto != null && baulBosqueDinero_CuadroTexto.checkInteraction() 
        && !secondaryMissions.Contains(2.1)){
            dinero.SumarDinero(2000);
            secondaryMissions.Add(2.1);
            baulBosqueDinero.OpenBaul();
        }
    }

    public bool CheckMainMission(float mission){
        if(mainMissions.Contains(mission)){
            return true;
        }
        return false;   
    }
    public bool CheckSecondaryMission(float mission){
        if(secondaryMissions.Contains(mission)){
            return true;
        }
        return false;
    }

    public List<double> GetSecondaryMissions(){
        return secondaryMissions;
    }
    public List<double> GetMainMissions(){
        return mainMissions;
    }
    public void Initialize(DatosJuego datosJuego){
        this.mainMissions = datosJuego.mainMissions;
        this.secondaryMissions = datosJuego.secondaryMissions;
        this.dinero = datosJuego.dinero;    
    }
}
