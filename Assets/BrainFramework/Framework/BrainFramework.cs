using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using WebSocketSharp;

//EMOTIV STUFF ALL HERE, REVIEW AND ARRANGE ACCORDING TO FLOW

public class BrainFramework : MonoBehaviour
{
    //Menu stuff
    [Header("Connection Socket URL")]
    public string socketUrl = "wss://localhost:6868";

    [Header("EPOC+ Headset")]

    //These were removed because they are linked to my account. Users need to provide their own inside here.
    public string clientId = "kA3HNG0kys3QhmGy8v2Ayirg66df6OwXINX8Akuj"; //PROVIDE A CLIENT ID IN THE EmotivController INTERFACE PANEL
    public string clientSecret = "FyTNi5izoXI8hv9UAQnbEg27aAA9oSjqzdgLXzrVJ0hhKpwtQssCSAMnE1tL9sK1x0LBdKk2ucrywbeaP9ZL6xbw805kGVmO2e3qOFrKLbP8ahDpVsbIGXMlS91OOnVm"; //PROVIDE A CLIENT SECRET IN THE EmotivController INTERFACE PANEL

    public string headsetId = "EPOCPLUS-3B9ADD0E";

    [Header("Profile")]
    public static string Profile = "may"; //Profile registered in Emotiv

    private WebSocket WS;
    private bool READY = false;
    private bool STREAM = false;
    private bool LoggedIn = false;
    private string TOKEN;
    private string SESSION;
    //private string TRAINING;

    public class BRAIN_CLASS
    {
        public string command = null;
        public string eyeAction = null;
        public string upperFaceAction = null;
        public string lowerFaceAction = null;
        public string metric = null; //added performance metric
    }

    public BRAIN_CLASS BRAIN = new BRAIN_CLASS();


    // Start is called before the first frame update
    void Start()
    {
        //DIAGRAM THIS FOR REPORT

        Connect();

        //Request Access
        On("UserLoggedIn", requestAccess);

        //Authorize
        On("AccessGranted", authorize);

        //Create Session
        On("Authorized", createSession);

        //Load Profile
        On("SessionCreated", () => {
            loadProfile("load");
        });
    }

    //Set up socket with the Unity one
    private void Connect()
    {
        Debug.Log("Connected");
        WS = new WebSocket(socketUrl);

        WS.OnOpen += _open;
        WS.OnMessage += _message;
        WS.OnClose += _close;

        WS.ConnectAsync();
    }

    private void _open(object sender, System.EventArgs e)
    {
        Debug.Log("Webserver Connected");

        //Must login
        getUserLogin();
    }

    private void _message(object sender, MessageEventArgs e)
    {
        Debug.Log(e.Data.ToString());
        //Deal with the messages
        if (!LoggedIn)
        {
            RES_LOG_CLASS FirstMsg = JsonUtility.FromJson<RES_LOG_CLASS>(e.Data.ToString());

            Debug.Log("first msg: " + FirstMsg.result[0].username);
            
            if (FirstMsg.result != null)
            {
                if (FirstMsg.result[0].currentOSUsername == FirstMsg.result[0].loggedInOSUsername)
                {
                    Debug.Log("You are logged into " + FirstMsg.result[0].username);
                    LoggedIn = true;
                    Emit("UserLoggedIn");
                }
                else
                {
                    Debug.LogError("Already logged in on another device.");
                }
            }
            else
            {
                Debug.LogError("Please login to the Emotiv App.");
            }

        }
        else
        {
            RES_CLASS msg = JsonUtility.FromJson<RES_CLASS>(e.Data.ToString());
            //Debug.Log("msg: " + msg.result.cortexToken);
            //Request Access
            if (msg.result.accessGranted)
            {
                if (msg.result.accessGranted)
                {
                    Debug.Log("Access Granted!");
                    Emit("AccessGranted");
                    //Debug.Log("request access username"+msg.result.accessGranted);

                }
                else
                {
                    Debug.LogError("Access rights not granted to the game. Please use Emotiv App to grant the rights, then restart Unity.");
                }
            }

            //Authorize
            if (msg.result.cortexToken != null)
            {
                TOKEN = msg.result.cortexToken;
                Debug.Log("Authorized");
                Emit("Authorized");
            }
            /* else
             {

                 Debug.Log("auth error code" + msg.result.error.code);

             }*/



            //Create the session
            if (msg.result.id != null)
            {
                SESSION = msg.result.id;
                Emit("SessionCreated");
            }

            //Load the player's profile
            if (msg.result.action != null && msg.result.name != null)
            {
                if (msg.result.action == "load")
                {
                    Debug.Log(msg.result.message + ": " + msg.result.name);

                    //Loaded, we are good to go!

                    READY = true;
                    Emit("READY");
                }
            }

            //Let's start streaming~~
            if (msg.result.failure != null)
            {
                Debug.Log("Streaming mental commands");
            }

            //Process the commands
            if (msg.com != null)
            {
                BRAIN.command = msg.com[0].ToString();
            }

            //Face...? TRY ONLY AH
            if (msg.fac != null)
            {
                BRAIN.eyeAction = msg.fac[0].ToString();
                BRAIN.upperFaceAction = msg.fac[1].ToString();
                BRAIN.lowerFaceAction = msg.fac[3].ToString();
            }

            //if (msg.met != null)
            //{
            //    Debug.Log("msg.met NOT NULL");
            //    for (int i = 0; i< BRAIN.metric.Length; i++)
            //    {
            //        Debug.Log("FOR LOOP EPOC Metric " + i + ": " + BRAIN.metric[i]);
            //    }
            //    BRAIN.metric = msg.met[0].ToString();
            //    Debug.Log("BrainFramework Metric: " + BRAIN.metric);

            //}

            if (msg.fac != null || msg.com != null)
            {
                Emit("STREAM");
            }
        }
    }

    private void _close(object sender, CloseEventArgs e)
    {
        Debug.Log("Webserver Closed:" + e.Reason);
    }

    //The requests to be made to Emotiv: VERIFY WITH EMOTIV DOCS (done :))
    private void getUserLogin()
    {
        string getUserLoginReq = @"{
            ""id"": 1, 
            ""jsonrpc"": ""2.0"", 
            ""method"": ""getUserLogin""
        }";

        WS.Send(getUserLoginReq);
    }

    private void requestAccess()
    {
        Debug.Log("RequestedAccess"); //extra
        string requestAccessReq = @"{
            ""id"": 1, 
            ""jsonrpc"": ""2.0"", 
            ""method"": ""requestAccess"",
            ""params"": {
                ""clientId"": """ + clientId + @""",
                ""clientSecret"": """ + clientSecret + @"""
            }
        }";

        WS.Send(requestAccessReq);
    }

    private void authorize()
    {
        Debug.Log("Authorized"); //extra
        string authorizeReq = @"{
            ""id"": 1, 
            ""jsonrpc"": ""2.0"", 
            ""method"": ""authorize"",
            ""params"": {
                ""clientId"": """ + clientId + @""",
                ""clientSecret"": """ + clientSecret + @"""
            }
        }";

        WS.Send(authorizeReq);
    }

    private void createSession()
    {
        Debug.Log("CreatedSession");
        string createSessionReq = @"{
            ""id"": 1, 
            ""jsonrpc"": ""2.0"", 
            ""method"": ""createSession"",
            ""params"": {
                ""cortexToken"": """ + TOKEN + @""",
                ""headset"": """ + headsetId + @""",
                ""status"": ""open""
            }
        }";

        WS.Send(createSessionReq);

    }

    private void loadProfile(string action)
    {
        Debug.Log("LoadedProfile: " + Profile);
        string loadProfileReq = @"{
            ""id"": 1, 
            ""jsonrpc"": ""2.0"", 
            ""method"": ""setupProfile"",
            ""params"": {
                ""cortexToken"": """ + TOKEN + @""",
                ""headset"": """ + headsetId + @""",
                ""profile"": """ + Profile + @""",
                ""status"": """ + action + @"""
            }
        }";

        WS.Send(loadProfileReq);
    }

    private void subscribe()
    {
        Debug.Log("Subscribed");
        string createSessionReq = @"{
            ""id"": 1, 
            ""jsonrpc"": ""2.0"", 
            ""method"": ""subscribe"",
            ""params"": {
                ""cortexToken"": """ + TOKEN + @""",
                ""session"": """ + SESSION + @""",
                ""streams"": [""com"",""fac"",""sys""]
            }
        }";

        WS.Send(createSessionReq);

        //We subscribed to the commands stream, we are good to go!
        STREAM = true;
    }

    //Minor helper if we need it
    public void StartStream()
    {
        Debug.Log("StartStream");
        if (!STREAM)
        {
            Debug.Log("Subscribing NOW");
            subscribe();
        }
    }

    //On and Emit event managers
    public void On(string Event, UnityAction Callback)
    {
        EventManager.On(Event, Callback);
    }

    public void Emit(string Event)
    {
        EventManager.Emit(Event);
    }
}




