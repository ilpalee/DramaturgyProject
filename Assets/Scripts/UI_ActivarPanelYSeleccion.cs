using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_ActivarPanelYSeleccion : MonoBehaviour
{


    public GameObject panelAActivar;
    public GameObject botonASeleccionar;


    public void ActivarPanelYSeleccionar()
    {
        // Activa el panel
        panelAActivar.SetActive(true);

        // Establece el nuevo boton como seleccionado
        EventSystem.current.SetSelectedGameObject(botonASeleccionar);
    }
   
    void Start()
    {
        
    }

   
    void Update()
    {

    }


}
