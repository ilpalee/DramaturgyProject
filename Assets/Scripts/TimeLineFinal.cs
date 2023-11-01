using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimeLineFinal : MonoBehaviour
{
    public string objectName1; // Nombre del objeto que contiene el primer Animator
    public string objectName2; // Nombre del objeto que contiene el segundo Animator
    public PlayableDirector director;
    public string animationTrackName1; // Nombre del primer Animation Track
    public string animationTrackName2; // Nombre del segundo Animation Track

    void Start()
    {
        // Encuentra los objetos en la escena por sus nombres
        GameObject objectToAssign1 = GameObject.Find(objectName1);
        GameObject objectToAssign2 = GameObject.Find(objectName2);

        if (objectToAssign1 != null && objectToAssign2 != null)
        {
            // Obtén referencias a los Animation Tracks específicos en el TimelineAsset
            TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;
            AnimationTrack animationTrack1 = null;
            AnimationTrack animationTrack2 = null;

            foreach (TrackAsset track in timelineAsset.GetOutputTracks())
            {
                if (track is AnimationTrack)
                {
                    if (track.name == animationTrackName1)
                    {
                        animationTrack1 = (AnimationTrack)track;
                    }
                    else if (track.name == animationTrackName2)
                    {
                        animationTrack2 = (AnimationTrack)track;
                    }
                }
            }

            if (animationTrack1 != null && animationTrack2 != null)
            {
                // Asigna los Animators a los Animation Tracks a través de SetGenericBinding
                director.SetGenericBinding(animationTrack1, objectToAssign1);
                director.SetGenericBinding(animationTrack2, objectToAssign2);
            }
            else
            {
                Debug.LogWarning("No se encontraron los Animation Tracks con los nombres especificados.");
            }
        }
        else
        {
            Debug.LogWarning("No se encontraron los objetos en la escena.");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
