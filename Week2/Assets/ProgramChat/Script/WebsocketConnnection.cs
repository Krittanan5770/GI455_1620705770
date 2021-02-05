using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;


namespace ProgramChat
{
  
    public class WebsocketConnnection : MonoBehaviour
    {

        public string userurl,userport,usermessage;
        public GameObject url;
        public GameObject port;
        public GameObject message;
        public GameObject display0;
        public GameObject display1;
        public GameObject display2;
        public GameObject display3;
        public GameObject CanvasA;
        public GameObject CanvasB;


        
        private WebSocket websocket;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if(websocket.ReadyState == WebSocketState.Open)
                {
                    websocket.Send("Random Number" + Random.Range(0, 999999));
                }
            }
        }

        public void Connection()
        {

            userurl = url.GetComponent<Text>().text;
            
            userport = port.GetComponent<Text>().text;
            
            websocket = new WebSocket("ws://" + userurl + ":" + userport + "/");

            websocket.OnMessage += OnMessage;

            websocket.Connect();
            
        }

        private void OnDestroy()
        {
            if(websocket != null)
            {
                websocket.Close();
            }
        }

        public void OnMessage(object sender,MessageEventArgs messageEventArgs)
        {
            Debug.Log("Receive msg : " + messageEventArgs.Data);
            display.GetComponent<Text>().text = messageEventArgs.Data;
        }
        public void Changescene()
        {
            CanvasA.SetActive(false);
            CanvasB.SetActive(true);
        }

        public void Sendmessage()
        {
            usermessage = message.GetComponent<Text>().text;
            
            if (websocket.ReadyState == WebSocketState.Open)
            {
                websocket.Send(usermessage);
            }
            

            
        } 
    }
}


