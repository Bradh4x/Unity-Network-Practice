using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    //[SyncVar] updates the objs in game to player = only server to client
    //[SyncVar(hook = OnChange)] to attach hook to changing variable - useful to update for all or just one client

    [SyncVar (hook = nameof(onHolaCountChanged))]
    int holaCount = 0;

    void HandleMovement(){  // This is a basic method for movement - not to be used in my game but good to know
        if (isLocalPlayer)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal * 0.1f, moveVertical * 0.1f, 0);
            transform.position = transform.position + movement;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.X)) // checks if control is coming from the attached player - checking if player presses X
        {
             Debug.Log("Sending Hola to Server");
             Hola();
        }

    }

    [Command]  // using this attribute makes it so that the code is being ran on server opposed to Client
    void Hola()
    {
        Debug.Log("Received Hola from Client");
        holaCount++;
        ReplyHola();
    }

    [TargetRpc] // sent from server to one single client using NetworkConnection Connection
    void ReplyHola()
    {
        Debug.Log("Received Hola from Server!");
    }

    [ClientRpc] // Sent from server to all clients
    void TooHigh()
    {
        Debug.Log("Were too High");
    }

    void onHolaCountChanged(int oldCount, int newCount){
        Debug.Log($"old count {oldCount} holas and new count {newCount}");
    }
}
