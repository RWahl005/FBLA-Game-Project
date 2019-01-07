using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour {

    ///
    /// This script is the main script of the game. It contains important game information.
    /// Access using: Camera.main.getComponent<MainGame>();
    ///

    /// <summary>
    /// The list of questions. (Not specific per game)
    /// </summary>
    public List<Question> questions;

    /// <summary>
    /// The game questions
    /// </summary>
    public GameQuestions gq;

    /// <summary>
    /// The curretn question the game is on.
    /// </summary>
    public int currentQuestion;

    /// <summary>
    /// The current mode the game is in.
    /// </summary>
    public GameMode currentMode;

    /// <summary>
    /// The number of questions to be added to the system.
    /// </summary>
    public int numberOfQuestions;

    /// <summary>
    /// If the game is paused. (Escape menu)
    /// </summary>
    public bool isPaused;


	// Use this for initialization
	void Start () {
        questions = new List<Question>();
        addQuestions();
        SortGameQuestions sq = new SortGameQuestions();
        gq = new GameQuestions(sq.sort(questions, (questions.Count - 1))); //TODO: Replace this with numberOfQuestions.
        currentQuestion = -1;
        currentMode = GameMode.Question;
        isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// New Questions are added here.
    /// </summary>
    private void addQuestions()
    {
        questions.Add(new Question("What is green?", new List<string> { "Red", "Blue", "Green", "IDK"}, 2));
        questions.Add(new Question("Who am I?", new List<string> { "No One", "Who Cares?", "Hungry", "o" }, 1));
        questions.Add(new Question("Example Question 1", new List<string> { "Answer A", "Answer B", "Answer C", "Answer D" }, 3));
    }

    public ActiveQuestions getCurrentQuestion()
    {
        return gq.getActiveQuestions()[currentQuestion];
    }
}
