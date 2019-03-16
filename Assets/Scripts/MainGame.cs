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

    public double roundTime;



    // Use this for initialization
    void Start() {
        SettingsManager sm = new SettingsManager();
        questions = new List<Question>();
        addQuestions();
        SortGameQuestions sq = new SortGameQuestions();
        if (sm.getSettingFloat("NumberOfQuestions") - 1 >= 1)
            gq = new GameQuestions(sq.sort(questions, ((int)sm.getSettingFloat("NumberOfQuestions")) - 1));
        else
        {
            gq = new GameQuestions(sq.sort(questions, 18));
        }
        numberOfQuestions = (int) sm.getSettingFloat("NumberOfQuestions");
        currentQuestion = -1;
        currentMode = GameMode.Question;
        isPaused = false;
        roundTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}
    /// <summary>
    /// New Questions are added here. (25 Questions)
    /// </summary>
    private void addQuestions()
    {
        questions.Add(new Question("What does FBLA stand for?", new List<string> { "Future Business Leaders of America", "Future Buisness Leaders of Alaska", "Future Buisness Launcher for America", "Nothing"}, 0));
        questions.Add(new Question("How many FBLA chapters are there?", new List<string> { "500", "6,100", "10,000", "900" }, 1));
        questions.Add(new Question("What is the post-secondary division of FBLA?", new List<string> { "PBL", "FBLA", "UBLA", "ZCA" }, 0));
        questions.Add(new Question("How many FBLA goals are there?", new List<string> { "9", "6", "4", "0" }, 0));
        questions.Add(new Question("What is one fundraiser FBLA does to help research against birth defects?", new List<string> { "March of Dimes", "Save Babies", "Red Cross", "They Do Not" }, 0));
        questions.Add(new Question("In what month(s) is the state conference usually held?", new List<string> { "March / April", "June / July", "January", "May" }, 0));
        questions.Add(new Question("Where is the FBLA national headquaters?", new List<string> { "Reston, VA", "New York City, NY", "Washington, DC", "Phoenix, AZ" }, 0));
        questions.Add(new Question("Where is the State Leadership Conference held in Arizona?", new List<string> { "Phoenix", "Flagstaff", "Tuscon", "Yuma" }, 2));
        questions.Add(new Question("Which one of these companies is a FBLA sponsor?", new List<string> { "Air Kansas", "Amazon", "Red Cross", "No One" }, 1));
        questions.Add(new Question("Where will the FBLA National Leadership Conference be held in 2019?", new List<string> { "San Antonio, Texas", "Baltimore, Maryland", "Phoenix, Arizona", "New York City, New York" }, 0));
        questions.Add(new Question("Which state was the first state chapter?", new List<string> { "Arizona", "Iowa", "New York", "Colorado" }, 1));
        questions.Add(new Question("When does a national officer's term begin?", new List<string> { "End of the National Leadership Confrence", "May", "January 1", "November 26" }, 0));
        questions.Add(new Question("Who is the Parliamentary Procedure Event named after?", new List<string> { "Alexander Grandbell", "John D. Rockefeller", "King George III", "Dorothy L. Travis" }, 3));
        questions.Add(new Question("What is the minimum number of members required to start a chapter?", new List<string> { "5", "1", "10", "30" }, 0));
        questions.Add(new Question("What month is FBLA week in?", new List<string> { "February", "March", "June", "December" }, 0));
        questions.Add(new Question("Where was the first FBLA local chapter made?", new List<string> { "Washington, DC", "New York City, NY", "Johnson City, TN", "Los Angeles, CA" }, 2));
        questions.Add(new Question("In order to compete, when must dues be received in the National Center?", new List<string> { "March 1st", "December 2nd", "September 15th", "November 30th" }, 0));
        questions.Add(new Question("When is American Enterprise Day?", new List<string> {  "July 4th", "November 15th", "April 15th", "June 3rd" }, 1));
        questions.Add(new Question("What are the official colors of FBLA?", new List<string> { "Blue and Gold", "Red and Blue", "Purple and Pink", "Green and Blue" }, 0));
        questions.Add(new Question("Who is the founder of FBLA?", new List<string> { "Hamden L. Forkner", "George Bush", "Steve Jobs", "Jeff Bezos" }, 0));
        questions.Add(new Question("In what year was the first chapter made?", new List<string> { "1947", "1812", "2001", "1979" }, 0));
        questions.Add(new Question("In what year was PBL made?", new List<string> { "1958", "1999", "2008", "1947" }, 0));
        questions.Add(new Question("What does PBL stand for?", new List<string> { "Phi Beta Lambda", "Phoenix Buisness Leaders", "Pennsylvania Buisness Leaders", "Nothing" }, 0));
        questions.Add(new Question("What does USDE stand for?", new List<string> { "United States Department of Education", "University Department of Education", "United States Department of Energy", "Nothing" }, 0));
        questions.Add(new Question("What is a short intermission in a buisness meeting called?", new List<string> { "Recess", "Break", "Intermission", "Hault" }, 0));
        questions.Add(new Question("How many local chapters must a state have to be issued a state charter?", new List<string> { "20", "30", "5", "1" }, 2));




    }

    public ActiveQuestions getCurrentQuestion()
    {
        return gq.getActiveQuestions()[currentQuestion];
    }
}
