using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimeLine2 : MonoBehaviour
{

    public string objectName; // Nombre del objeto que contiene el Animator
    public PlayableDirector director;
    public string animationTrackName;

    // Start is called before the first frame update
    void Start()
    {
        // Encuentra el objeto en la escena por su nombre
        GameObject objectToAssign = GameObject.Find(objectName);

        if (objectToAssign != null)
        {
            // Obtén una referencia al Animation Track específico en el TimelineAsset
            TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;
            AnimationTrack animationTrack = null;

            foreach (TrackAsset track in timelineAsset.GetOutputTracks())
            {
                if (track is AnimationTrack && track.name == animationTrackName)
                {
                    animationTrack = (AnimationTrack)track;
                    break;
                }
            }

            if (animationTrack != null)
            {
                // Asigna el Animator al Animation Track a través de SetGenericBinding
                director.SetGenericBinding(animationTrack, objectToAssign);
            }
            else
            {
                Debug.LogWarning("No se encontró el Animation Track con el nombre especificado.");
            }
        }
        else
        {
            Debug.LogWarning("No se encontró el objeto en la escena.");
        }
    }
}
