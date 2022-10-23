using UnityEngine.Events;
using UnityEngine;


[System.Serializable]
public class EmptyEvent : UnityEvent
{

}
[System.Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject> 
{ 
}


public class MainEventListener : MonoBehaviour
{
    public MainEvent gEvent;
    public EmptyEvent response = new EmptyEvent();

    private void OnEnable()
    {
        gEvent.Register(this);
    }

    private void OnDisable()
    {
        gEvent.Unregister(this);
    }

    public void OnEventOccurs()
    {
        response.Invoke();
    }
}
