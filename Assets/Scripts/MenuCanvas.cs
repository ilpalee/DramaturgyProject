using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    public GameObject Texto1;
    public GameObject Texto2;
    public GameObject Texto3;
    public GameObject Texto4;
    
    public Button Boton_Play;
    public Button Boton_Salir;
    public Button Boton_Controles;

    public GameObject PanelControles;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Boton_Play.onClick.AddListener(DisableInteractable);
        Boton_Salir.onClick.AddListener(DisableInteractable);
        //Boton_Controles.onClick.AddListener(DisableInteractable);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Salir()
    {
        Debug.Log("Cerrando Juego");
        Application.Quit();
    }

    public void DesactivarUI()
    {
        Texto1.SetActive(false);
        Texto2.SetActive(false);
        Texto3.SetActive(false);
        Texto4.SetActive(false);
        PanelControles.SetActive(false);
    }

    void DisableInteractable()
    {
        // Desactivar la propiedad Interactable del boton
        Boton_Play.interactable = false;
        Boton_Salir.interactable = false;
        //Boton_Controles.interactable = false;
        
    }

}
