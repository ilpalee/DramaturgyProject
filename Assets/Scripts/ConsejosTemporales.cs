using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsejosTemporales : MonoBehaviour
{

    public GameObject Panel_Consejo_1;
    private float TiempoPanelConsejo = 3f;

    public GameObject Consejo1;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Consejo_1"))
        {
            Panel_Consejo_1.SetActive(true);
            Consejo1 = GameObject.FindGameObjectWithTag("Consejo_1");
        }

    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Consejo_1"))
        {
            Consejo1.SetActive(false);
            StartCoroutine(DesactivarPanelConsejo());
        }

    }

    private IEnumerator DesactivarPanelConsejo()
    {
        yield return new WaitForSeconds(TiempoPanelConsejo);
        Panel_Consejo_1.SetActive(false);
        
    }


}
