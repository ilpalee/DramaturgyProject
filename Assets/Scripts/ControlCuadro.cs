using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCuadro : MonoBehaviour
{

    public InteraccionEspecifica IntEsp;

    public GameObject CuadroAntagonista;
    public GameObject CuadroPj;
    public GameObject TriggerCuadro;

    void Start()
    {
        
    }

 

    void Update()
    {
        if(IntEsp.CondicionActiva == true)
        {
            CuadroAntagonista.SetActive(false);
            CuadroPj.SetActive(true);
            TriggerCuadro.SetActive(true);
        }

    }



}
