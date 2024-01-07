using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madera_Chimenea : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite BaldeVacio;

    public GameObject TroncoRecolectable;

    private bool Flag = false;

    private bool MaderaEnInventario = false;
    public GameObject ColliderTextoChimenea;
    public GameObject ColliderUsarChimenea;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Flag && TroncoRecolectable == null)
        {
            spriteRenderer.sprite = BaldeVacio;
            MaderaEnInventario = true;
            Flag = true;
        }

        if (MaderaEnInventario == true)
        {
            ColliderTextoChimenea.SetActive(false);
            ColliderUsarChimenea.SetActive(true);
        }

    }
}
