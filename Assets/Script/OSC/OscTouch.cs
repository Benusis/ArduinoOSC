using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscTouch : MonoBehaviour
{
    public OSC Osc;
    public string TouchHeader = "/Touch";
    public int Touch = 0; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        Osc = gameObject.GetComponent<OSC>();


        Osc.SetAddressHandler(TouchHeader, OnTouchValue);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTouchValue(OscMessage message)
    {
        Touch = message.GetInt(0);
    }





}
