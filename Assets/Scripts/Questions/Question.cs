using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Question : ICloneable {
    /*
     * Question script. Make a new question by doing Question q = new Question(data);
     */

    private string question;
    private List<string> answers;
    private int correctAnswer;

    /**
     * Define a new question.
     * string question = the question
     * List<string> answers are the answers
     * int correctAnswer is the correct answer (starts at 0)
     */
    public Question(string question, List<string> answers, int correctAnswer)
    {
        this.question = question;
        this.answers = answers;
        this.correctAnswer = correctAnswer;
    }

    /**
     * Get the question
     */
    public string getQuestion()
    {
        return question;
    }


    /**
     * Get the answers.
     */
    public List<string> getAnswers()
    {
        return answers;
    }

    /**
     * Get the correct answer.
     */
    public int getCorrectAnswer()
    {
        return correctAnswer;
    }


    /// <summary>
    /// Clones the object. (Does not work with the list)
    /// Use this if you intend of changing the value of it in another variable (see: ActiveQuestions.cs)
    /// </summary>
    /// <returns>The clone of the object.</returns>
    public object Clone()
    {
        return this.MemberwiseClone();
    }

}
