using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraRefresh : MonoBehaviour
{
    
    public Vector2 MaxCameraPos;
    public Vector2 MinCameraPos;
    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Personaje1"))
        {
            
            CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();
            if (cameraFollow != null)
            {
                cameraFollow.SetCameraLimits(MinCameraPos, MaxCameraPos);
            }
        }
    }






}





