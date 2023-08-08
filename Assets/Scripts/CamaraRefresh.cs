using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraRefresh : MonoBehaviour
{

    public Vector2 camMaxChange;
    public Vector2 camMinChange;

    public Vector3 playerChange;

    private CameraFollow cam;
    private Vector2 originalCamMax;
    private Vector2 originalCamMin;
    
    void Start()
    {
        cam = Camera.main.GetComponent<CameraFollow>();
        originalCamMax = cam.MaxPos;
        originalCamMin = cam.MinPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Personaje1")
        {
            ActualizacionCamara(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Personaje1")
        {
            RestaurarCamara();
        }
    }

    private void ActualizacionCamara(Collider2D other)
    {
        cam.MaxPos = new Vector2(originalCamMax.x + camMaxChange.x, originalCamMax.y + camMaxChange.y);
        cam.MinPos = new Vector2(originalCamMin.x + camMinChange.x, originalCamMin.y + camMinChange.y);

        other.transform.position += playerChange;
    }

    private void RestaurarCamara()
    {
        cam.MaxPos = originalCamMax;
        cam.MinPos = originalCamMin;
    }

}
