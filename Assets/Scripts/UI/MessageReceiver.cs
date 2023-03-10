using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageReceiver : MonoBehaviour
{
    public void HandleMessage(string message)
    {
        Debug.Log("Received message: " + message);
    }
}
