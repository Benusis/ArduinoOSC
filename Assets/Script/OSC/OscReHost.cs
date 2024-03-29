using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscReHost : MonoBehaviour
{

    public OSC osc;
    public string Header = "/Host";
    public int InPort = 9001;
    public int OutPort = 9000;

    public bool ReHostOnRestart = true;
    public bool ReHost = false;




    // Start is called before the first frame update
    void Start()
    {
        osc = gameObject.GetComponent<OSC>();
        ReHost = false;




        if (ReHostOnRestart)
        {
            InPort = osc.outPort;
            OutPort = osc.inPort;

            SendReHost();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (ReHost)
        {
            SendReHost();
        }



    }


    public void SendReHost()
    {
        OscMessage message = new OscMessage();
        message.address = Header;
        message.values.Add(InPort);
        message.values.Add(OutPort);
        osc.Send(message);
        ReHost = false;
    }


}
