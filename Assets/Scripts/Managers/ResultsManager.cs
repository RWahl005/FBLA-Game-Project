using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsManager : MonoBehaviour {

    /// <summary>
    /// Manages the Results UI
    /// </summary>

    public GameObject ResultPanel;
    public Text a;
    public Text b;
    public Text c;
    public Text d;
    public Text question;
    public Text answer;
    public Text urAnswer;
    public Text time;

    private StoreData data;

	// Use this for initialization
	void Start () {
        data = Camera.main.GetComponent<StoreData>();
	}

    double timeLeft = 9;

    private void Update()
    {
        if (Camera.main.GetComponent<MainGame>().isPaused)
            return;
        if (Camera.main.GetComponent<MainGame>().currentMode == GameMode.Results)
        {
            timeLeft -= Time.deltaTime;
            time.text = System.Math.Truncate(timeLeft) + "";
            if(timeLeft < 4)
            {
                time.color = Color.red;
            }
            if (timeLeft < 0)
            {
                timeLeft = 9;
            }
        }
    }

    public void startResults()
    {
        ActiveQuestions lastQuestion = data.getLatestQuestion().Item2;
        ResultPanel.SetActive(true);
        a.text = "A) " + lastQuestion.getAnswers()[0];
        b.text = "B) " + lastQuestion.getAnswers()[1];
        c.text = "C) " + lastQuestion.getAnswers()[2];
        d.text = "D) " + lastQuestion.getAnswers()[3];
        question.text = lastQuestion.getBaseQuestion().getQuestion();
        answer.text = translateNumberToLetter(lastQuestion.getCorrectAnswer());
        urAnswer.text = translateNumberToLetter(data.getLatestQuestion().Item3);

        timeLeft = 9;
        time.color = Color.black;
    }
    public void endResults()
    {
        ResultPanel.SetActive(false);
    }

    string translateNumberToLetter(int num)
    {
        switch(num){
            case 0:
                return "A";
            case 1:
                return "B";
            case 2:
                return "C";
            case 3:
                return "D";
        }
        return "DQ";
    }
}
