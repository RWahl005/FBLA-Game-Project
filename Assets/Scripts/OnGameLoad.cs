using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameLoad : MonoBehaviour
{

    public GameObject settings;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("new"))
        {
            Camera.main.GetComponent<Settings>().OnSettings();
            WindowUI wui = new WindowUI(WindowImage.INFO, WindowType.OK, new List<string> { "Continue" }, "Confirm Settings", "Welcome to the game! Please confirm these are the settings you want to play with! When done click the back button. This menu will only popup this time. The settings can be edited later from the main menu.", false, 0, ExitDefault.CLOSEOPERATION);
            PlayerPrefs.SetString("new", "true");
            PlayerPrefs.SetFloat("NumberOfQuestions", 18f);
            PlayerPrefs.SetString("BackgroundCars", "true");
        }

    }

}
