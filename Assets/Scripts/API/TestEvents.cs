using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvents : MonoBehaviour, IEventHandler
{
    // Start is called before the first frame update
    void Start()
    {
        GameAPI.api.registerHandler(this);
    }

    [EventHandler]
    public void onTrigger(CarHitTriggerEvent e)
    {
        Debug.Log("It worked some how!");
        Debug.Log(e.getDataUser() + "");
        Debug.Log(e.getTriggerName());
    }

    [EventHandler]
    public void onSettings(OnSettingsMenuEvent e)
    {
        Debug.Log("Opened the settings menu!");
    }
}
