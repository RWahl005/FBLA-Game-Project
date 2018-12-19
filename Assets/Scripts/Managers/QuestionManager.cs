using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour {

    /// <summary>
    /// Manges the question portion of the game. (When the question UI is displayed)
    /// When the game ends it is triggered here.
    /// </summary>

    public GameObject questionPanel;
    public Text a;
    public Text b;
    public Text c;
    public Text d;
    public Text question;
    public Text time;

    private MainGame game;

    // Use this for initialization
    void Start () {
        game = Camera.main.GetComponent<MainGame>();
	}

    double timeLeft = 12;

    private void Update()
    {
        if (Camera.main.GetComponent<MainGame>().currentMode == GameMode.Question)
        {
            timeLeft -= Time.deltaTime;
            time.text = System.Math.Truncate(timeLeft) + "";
            if (timeLeft < 4)
            {
                time.color = Color.red;
            }
            if (timeLeft < 0)
            {
                timeLeft = 12;
            }
        }

        if(game.currentQuestion >= game.gq.getActiveQuestions().Count)
        {
            game.currentMode = GameMode.End;
            Debug.Log("Game Over");
            game.currentQuestion = 0;
        }
    }

    public void nextQuestion()
    {
        if(game.currentQuestion >= game.gq.getActiveQuestions().Count)
        {
            game.currentMode = GameMode.End;
            return;
        }

        game.currentQuestion += 1;
        ActiveQuestions aq = game.getCurrentQuestion();

        questionPanel.SetActive(true);
        a.text = "A) " + aq.getAnswers()[0];
        b.text = "B) " + aq.getAnswers()[1];
        c.text = "C) " + aq.getAnswers()[2];
        d.text = "D) " + aq.getAnswers()[3];
        question.text = aq.getBaseQuestion().getQuestion();

        timeLeft = 12;
        time.color = Color.black;
    }

    public void endQuestion()
    {
        questionPanel.SetActive(false);
    }
}
