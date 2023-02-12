using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneManager : MonoBehaviour
{

    public Transform PuntoSpawn;
    public GameObject Personaje;

    

    void Start()
    {
        

        Personaje = GameObject.FindGameObjectWithTag("Personaje1");
        PuntoSpawn = GameObject.FindGameObjectWithTag("PuntoSpawn").transform;

        ReaparecerEnElPuntoSpawn();

    }

    
    void Update()
    {
        
    }

    public void ReaparecerEnElPuntoSpawn()
    {
        Personaje.transform.position = PuntoSpawn.position;
    }

    public void CambioEscenas()
    { 
        SceneManager.LoadScene(1);
    }
    
    

}
