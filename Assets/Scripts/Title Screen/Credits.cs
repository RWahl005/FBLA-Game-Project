using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject ui;
    public GameObject credits;

    // Start is called before the first frame update
    void Start()
    {
        credits.SetActive(false);
    }

    public void onInstruct()
    {
        GameAPI.api.callEvent(new OnMenuOpenEvent(Menus.Credits));
        credits.SetActive(true);
        ui.SetActive(false);
    }

    public void onBack()
    {
        ui.SetActive(true);
        credits.SetActive(false);
    }
}
