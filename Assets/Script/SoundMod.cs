using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMod : MonoBehaviour
{
    public OscTouch OscTouch;
    public AudioSource AS;


    [Header("Sound Pitch")]
    public float PitchMax = 1;
    public float PitchMin = 0;

    [Header("Touch Value")]
    public int TouchMax = 56;
    public int TouchMin = 26;


    public int TouchValue = 0; 
    public float res;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        TouchValue = OscTouch.Touch;
        res = Map((float)TouchValue, (float)TouchMin, (float)TouchMax,PitchMin, PitchMax);
        AS.pitch = res;

    }

    float Map(float val, float in1, float in2, float out1, float out2)
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }

}
