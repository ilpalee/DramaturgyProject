using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerInfoRopa : MonoBehaviour
{

    private bool TriggerInfo_Ropa;
    public GameObject Panel_Info_Ropa;
    

    void Awake()
    {
        Panel_Info_Ropa = GameObject.Find("Cont_Panel_InfoRopa");
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && TriggerInfo_Ropa == true)
        {
            Panel_Info_Ropa.transform.Find("Panel_Ropa").gameObject.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Personaje1"))
        {
            TriggerInfo_Ropa = true;
        }

    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Personaje1"))
        {
            TriggerInfo_Ropa = false;
            Panel_Info_Ropa.transform.Find("Panel_Ropa").gameObject.SetActive(false);
        }

    }


}
