using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConsejosTemporales : MonoBehaviour
{

    public GameObject Panel_Consejo_1;
    private float TiempoPanelConsejo = 3f;

    public GameObject Panel_Consejo_2;

    public GameObject Panel_Consejo_3;
    private float TiempoPanelConsejo_3 = 3.5f;

    public GameObject Consejo1;
    public GameObject Consejo2;
    public GameObject Consejo2_2;

    private GameObject ColliderBloqueoEscalera_1;
    private GameObject ColliderBloqueoEscalera_2;

    private bool FlagEscalera = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Inventario.DesactivarBloqueoEscalera && FlagEscalera == false)
        {
            ColliderBloqueoEscalera_1 = GameObject.FindGameObjectWithTag("Escalera_1");
            ColliderBloqueoEscalera_2 = GameObject.FindGameObjectWithTag("Escalera_2");
            ColliderBloqueoEscalera_1.SetActive(false);
            ColliderBloqueoEscalera_2.SetActive(false);
            Consejo2.SetActive(false);
            Consejo2_2.SetActive(false);
            Panel_Consejo_3.SetActive(true);
            StartCoroutine(DesactivarPanelConsejo3());
            FlagEscalera = true;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "EntradaCasa")
        {
            Consejo1 = GameObject.FindGameObjectWithTag("Consejo_1");
            Consejo2 = GameObject.FindGameObjectWithTag("Consejo_2");
            Consejo2_2 = GameObject.FindGameObjectWithTag("Consejo2_2");
        }
    }


    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Consejo_1"))
        {
            Panel_Consejo_1.SetActive(true);
            
        }

        if (coll.CompareTag("Consejo_2"))
        {
            Panel_Consejo_2.SetActive(true);
            
        }

        if (coll.CompareTag("Consejo2_2"))
        {
            Panel_Consejo_2.SetActive(true);
            
        }
            

    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Consejo_1"))
        {
            Consejo1.SetActive(false);
            StartCoroutine(DesactivarPanelConsejo());
        }

        if (coll.CompareTag("Consejo_2"))
        {
            Panel_Consejo_2.SetActive(false);
        }

        if (coll.CompareTag("Consejo2_2"))
        {
            Panel_Consejo_2.SetActive(false);
        }

    }

    private IEnumerator DesactivarPanelConsejo()
    {
        yield return new WaitForSeconds(TiempoPanelConsejo);
        Panel_Consejo_1.SetActive(false);
        
    }

    private IEnumerator DesactivarPanelConsejo3()
    {
        yield return new WaitForSeconds(TiempoPanelConsejo_3);
        Panel_Consejo_3.SetActive(false);
        
    }






}
