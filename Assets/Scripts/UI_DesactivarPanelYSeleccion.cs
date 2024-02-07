using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_DesactivarPanelYSeleccion : MonoBehaviour
{

    public GameObject panelADesactivar;
    public GameObject botonASeleccionar;


    public void DesactivarPanelYSeleccionar()
    {
        // Activa el panel
        panelADesactivar.SetActive(false);

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
