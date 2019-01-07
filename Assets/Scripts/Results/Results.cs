using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Results : MonoBehaviour
{

    public Text res;
    private StoreData sd;

    // Start is called before the first frame update
    void Start()
    {
        sd = DataStore.sd;
        res.text = sd.getTotalOfCorrectAnswers() + " / " + sd.getTotalNumberOfQuestions();
    }

    public void backToMain()
    {
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
