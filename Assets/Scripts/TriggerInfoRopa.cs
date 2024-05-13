using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerInfoRopa : MonoBehaviour
{

    private bool TriggerInfo_Ropa;
    public GameObject Panel_Info_Ropa;
    
    public GameObject Anim_Int_Maniqui;
    public GameObject Anim_Int_Espejo;
    private bool Activa_Anim_Int;

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
            Activa_Anim_Int = true;
        }

        if (Activa_Anim_Int)
        {
            Anim_Int_Espejo.SetActive(true);
            Anim_Int_Maniqui.SetActive(true);
            Activa_Anim_Int = false;
        }

        if(Inventario.Vestidor_Completo)
        {
            Anim_Int_Espejo.SetActive(false);
            Anim_Int_Maniqui.SetActive(false);
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
