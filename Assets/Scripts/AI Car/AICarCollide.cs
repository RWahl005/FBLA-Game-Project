using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarCollide : MonoBehaviour
{

    private MainGame game;
    private AICarScript ai;
    private DataUser du;

    // Start is called before the first frame update
    void Start()
    {
        game = Camera.main.GetComponent<MainGame>();
        ai = gameObject.GetComponent<AICarScript>();
        du = ai.getUser();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TriggerZone>() != null)
        {
            switch (other.gameObject.GetComponent<TriggerZone>().name)
            {
                case "A":
                    GameAPI.api.callEvent(new CarHitTriggerEvent(du, "A"));
                    break;
                case "B":
                    GameAPI.api.callEvent(new CarHitTriggerEvent(du, "B"));
                    break;
                case "C":
                    GameAPI.api.callEvent(new CarHitTriggerEvent(du, "C"));
                    break;
                case "D":
                    GameAPI.api.callEvent(new CarHitTriggerEvent(du, "D"));
                    break;
            }
        }
    }
}
