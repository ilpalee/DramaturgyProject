using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Objetivo;
    public float Smooth;

    public Vector2 MaxPos;
    public Vector2 MinPos;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Actualizacion de los valores max y min de la camara, teniendo en cuenta los predefinidos en el script "CamaraRefresh"

    public void SetCameraLimits(Vector2 minPos, Vector2 maxPos)
    {
        MaxPos = maxPos;
        MinPos = minPos;
    }

    // La camara main sigue el movimiento del personaje + valores iniciales de max y min como limite.

    void FixedUpdate()
    {
        if(transform.position != Objetivo.position)
        {
            Vector3 ObjetivoPos = new Vector3 (Objetivo.position.x, Objetivo.position.y, transform.position.z);

            ObjetivoPos.x = Mathf.Clamp(ObjetivoPos.x, MinPos.x, MaxPos.x);
            ObjetivoPos.y = Mathf.Clamp(ObjetivoPos.y, MinPos.y, MaxPos.y);

            transform.position = Vector3.Lerp(transform.position, ObjetivoPos, Smooth);

        }
    }

}
