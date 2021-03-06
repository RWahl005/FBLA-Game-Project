﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Text total;

    private MainGame game;

    // Use this for initialization
    void Start () {
        game = Camera.main.GetComponent<MainGame>();
	}

    double timeLeft = 9;

    private void Update()
    {
        if (Camera.main.GetComponent<MainGame>().isPaused)
            return;
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
                timeLeft = 9;
            }
        }

        if(game.currentQuestion >= game.gq.getActiveQuestions().Count)
        {
            game.currentMode = GameMode.End;
            game.currentQuestion = 0;
            DataStore.sd = Camera.main.GetComponent<StoreData>();
            SceneManager.LoadScene("Results", LoadSceneMode.Single);
            SceneManager.LoadScene("Results", LoadSceneMode.Single);
        }
    }

    public void nextQuestion()
    {
        if(game.currentQuestion >= game.gq.getActiveQuestions().Count)
        {
            game.currentMode = GameMode.End;
            return;
        }
        else
        {
            game.currentQuestion += 1;
        }
        ActiveQuestions aq;
        try
        {
            aq = game.getCurrentQuestion();
        }
        catch (System.ArgumentOutOfRangeException e) //Fixes that error with the index value being off.
        {
            aq = game.gq.getActiveQuestions()[0];
        }

        questionPanel.SetActive(true);
        a.text = "A) " + aq.getAnswers()[0];
        b.text = "B) " + aq.getAnswers()[1];
        c.text = "C) " + aq.getAnswers()[2];
        d.text = "D) " + aq.getAnswers()[3];
        question.text = aq.getBaseQuestion().getQuestion();
        total.text = (game.currentQuestion + 1) + " / " + game.numberOfQuestions;

        timeLeft = 9;
        time.color = Color.black;
    }

    public void endQuestion()
    {
        questionPanel.SetActive(false);
    }
}
