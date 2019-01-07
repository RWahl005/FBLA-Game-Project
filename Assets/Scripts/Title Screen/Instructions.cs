using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject ui;
    public GameObject instructions;

    // Start is called before the first frame update
    void Start()
    {
        instructions.SetActive(false);
    }

    public void onInstruct()
    {
        instructions.SetActive(true);
        ui.SetActive(false);
    }

    public void onBack()
    {
        ui.SetActive(true);
        instructions.SetActive(false);
    }
}
