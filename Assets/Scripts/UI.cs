using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Obsolete]
public class UI : MonoBehaviour {
    /// <summary>
    /// UNUSED. TO BE REMOVED.
    /// </summary>

    public MainGame g;

    public Text question;
    public Text a;
    public Text b;
    public Text c;
    public Text d;
    public Text correct;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ActiveQuestions aq = g.getCurrentQuestion();
        question.text = aq.getBaseQuestion().getQuestion();
        a.text = "A) " + aq.getAnswers()[0];
        b.text = "B) " + aq.getAnswers()[1];
        c.text = "C) " + aq.getAnswers()[2];
        d.text = "D) " + aq.getAnswers()[3];
        correct.text = "Correct Answer:" + aq.getAnswers()[aq.getCorrectAnswer()];
        
    }

    public void nextQuestion()
    {
        g.currentQuestion += 1;
    }
}
