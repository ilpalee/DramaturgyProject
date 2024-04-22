using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CV_Switch : MonoBehaviour
{
    public GameObject CamaraTransicion;
    public GameObject CamaraMain;
    public Player_1_Controller Player_1_Controller_Script;

    public bool condicion = true;

    public float TiempoEjecucion;
    public float TiempoEjecucion2;

    // Start is called before the first frame update
    void Start()
    {
        Player_1_Controller_Script = FindObjectOfType<Player_1_Controller>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (condicion == false)
        {
            Player_1_Controller_Script.MovementInput = false;
            Player_1_Controller_Script.anim.enabled = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Personaje1")
        {
            CamaraMain.SetActive(false);
            CamaraTransicion.SetActive(true);
            Invoke("DespuesDelTiempo", TiempoEjecucion);
            condicion = false;
        }

    }

    private void DespuesDelTiempo()
    {
        CamaraTransicion.SetActive(false);
        Invoke("DespuesDelTiempo2", TiempoEjecucion2);
    }

    private void DespuesDelTiempo2()
    {
        CamaraMain.SetActive(true);
        condicion = true;
        Destroy(gameObject);
    }


}
