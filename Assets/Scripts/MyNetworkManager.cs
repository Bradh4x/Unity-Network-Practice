using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    public override void OnStartServer()
    {
        Debug.Log("Server Started");
    }

    public override void OnStopServer()
    {
        Debug.Log("Server Stopped");
    }

    public override void OnClientConnect(NetworkConnection connection){
        Debug.Log("Client Connected to Server");
    }

    public override void OnClientDisconnect(NetworkConnection connection){
        Debug.Log("Client Disconnected from Server");
    }
}
