using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event", fileName = "New Game Event")]
public class GameEvent : ScriptableObject
{
    private HashSet<GameEventListener> listener = new HashSet<GameEventListener>();

    public void Invoke()
    {
        foreach (var globalEventListener in listener)
        {
            globalEventListener.RaiseEvent();
        }
    }

    public void Register(GameEventListener gameEventListener) => listener.Add(gameEventListener);
    public void Deregister(GameEventListener gameEventListener) => listener.Remove(gameEventListener);
}
