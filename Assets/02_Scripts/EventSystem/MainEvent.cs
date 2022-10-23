using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName ="DeepCave/Events", order = 52)]
public class MainEvent : ScriptableObject
{
    [SerializeField]
    private List<MainEventListener> eListener = new List<MainEventListener>();

    public void Register(MainEventListener listener)
    {
        eListener.Add(listener);
    }

    public void Unregister (MainEventListener listener)
    {
        eListener.Remove(listener);
    }

    public void Occured()
    {
        foreach(MainEventListener listener in eListener)
        {
            listener.OnEventOccurs();
        }

    }



}
