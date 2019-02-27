using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScoreHandler : MonoBehaviour, IEventHandler
{
    private StoreData sd;
    // Start is called before the first frame update
    void Start()
    {
        sd = Camera.main.GetComponent<StoreData>();
        GameAPI.api.registerHandler(this);
    }

    [EventHandler]
    public void onTriggerEvent(CarHitTriggerEvent e)
    {
        if (e.getTriggerName() == "Results" || e.getTriggerName() == "Questions") return;
        switch (e.getTriggerName())
        {
            case "A":
                break;
            case "B":
                break;
            case "C":
                break;
            case "D":
                break;
        }
    }
}
