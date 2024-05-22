using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Playable_Director : MonoBehaviour
{

    public PlayableDirector playableDirector;
    public static bool Playable_Director_Bool;

    private bool Flag_1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Flag_1 && playableDirector.state == PlayState.Playing)
        {
            Playable_Director_Bool = true;
            Flag_1 = true;
        }

        if (Flag_1 && playableDirector.state != PlayState.Playing)
        {
            Flag_1 = false;
            Playable_Director_Bool = false;
        }
    }
}
