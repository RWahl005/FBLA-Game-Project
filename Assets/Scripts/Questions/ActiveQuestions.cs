using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ActiveQuestions {

    private string question;
    private List<string> answers;
    private int correctAnswer;
    private Question baseQuestion;

    public ActiveQuestions(Question baseQuestion)
    {
        question = (string) baseQuestion.getQuestion().Clone();
        answers = new List<string>(baseQuestion.getAnswers());
        this.baseQuestion = (Question) baseQuestion.Clone();

        setupQuestion();
        
    }

    private void setupQuestion()
    {
        shuffleList(answers);
        correctAnswer = answers.FindIndex(a => a == baseQuestion.getAnswers()[baseQuestion.getCorrectAnswer()]);
        
    }

    private void shuffleList(List<string> list)
    {
        System.Random rnd = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rnd.Next(n + 1);
            string value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        answers = list;
    }

    public Question getBaseQuestion()
    {
        return baseQuestion;
    }

    public List<String> getAnswers()
    {
        return answers;
    }

    public int getCorrectAnswer()
    {
        return correctAnswer;
    }
}
