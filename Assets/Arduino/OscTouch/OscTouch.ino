#include <ArduinoOSCWiFi.h>


// WiFi stuff
const char* ssid = "TouchOSC2";
const char* pwd = "0123456789";
const IPAddress ip(192, 168, 4, 1);
const IPAddress gateway(192, 168,4, 1);
const IPAddress subnet(255, 255, 255, 0);

// ArduinoOSC
String host = "192.168.4.2";
int In_port = 9000;
int Out_port = 9001;

// Touch 
int TouchValue = 0; 
const char* TouchHeader = "/Touch";

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  delay(2000);

  // WiFi AP Mode
  WiFi.softAPConfig(ip, gateway, subnet);
  WiFi.softAP(ssid, pwd);
  Serial.print("WiFi AP IP = ");
  Serial.println(WiFi.softAPIP());
 
  //ReHost
  OscWiFi.subscribe(In_port, "/ReHost", onReHostReceived);
}




//OSC ReHost Fonction 
void onReHostReceived(const OscMessage& m) {
        host = m.remoteIP();
        In_port = m.arg<int>(0);
        Out_port = m.arg<int>(1);
        Serial.println("Re Host To:" + host + " Recv:"+ In_port +" Send:" + Out_port);
}


void loop() {
  // put your main code here, to run repeatedly:

    TouchValue = touchRead(T0);
    OscWiFi.send(host, Out_port, TouchHeader , TouchValue);
}
