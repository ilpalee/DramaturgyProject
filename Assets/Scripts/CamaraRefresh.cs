using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraRefresh : MonoBehaviour
{

    public Vector2 camMaxChange;
    public Vector2 camMinChange;

    public Vector3 playerChange;

    private CameraFollow cam;
    
    void Start()
    {
        cam = Camera.main.GetComponent<CameraFollow>();

    }

    
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Personaje1")
        {
            ActualizacionCamara(other);
        }
    }

    private void ActualizacionCamara(Collider2D other)
    {
        cam.MaxPos += camMaxChange;
        cam.MinPos += camMinChange;

        other.transform.position += playerChange;
    }


}
