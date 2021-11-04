using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    [Tooltip("Event to listen to.")]
    public GameEvent Event;

    [Tooltip("Response to the event raised.")]
    public UnityEvent Response;

    public void OnEnable()
    {
        Event.Register (this);
    }

    public void OnDisable()
    {
        Event.UnRegister (this);
    }

    public void OnEventRaised()
    {
        Response.Invoke ();
    }
}
