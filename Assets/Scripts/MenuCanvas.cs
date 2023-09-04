using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour
{
    public GameObject Texto1;
    public GameObject Texto2;
    public GameObject Texto3;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

}
