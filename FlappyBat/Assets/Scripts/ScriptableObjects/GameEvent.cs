using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu (fileName = "GameEvent", menuName = "Custom Scripts/Scriptable Objects/GameEvents/GameEvent", order = 0)]
public class GameEvent : CustomScriptableObject
{
    private readonly List<EventListener> listeners = new List<EventListener>();

    public void Register(EventListener eventListener)
    {
        if (!listeners.Contains (eventListener))
            listeners.Add (eventListener);
    }
    public void UnRegister(EventListener eventListener)
    {
        if (!listeners.Contains (eventListener))
            listeners.Remove (eventListener);
    }

    [ContextMenu("RaiseEvent")]
    public void RaiseEvent()
    {
        Debug.Log ("Event raised - " + this);
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised ();
        }
    }
}
