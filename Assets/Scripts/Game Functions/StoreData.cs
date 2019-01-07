﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreData : MonoBehaviour {
    /// <summary>
    /// Stores the data temporarly
    /// TODO: When the results screen is about to be loaded save this in a non-destoryable object and send it over.
    /// </summary>

    public List<Tuple<string, ActiveQuestions, int>> data;

    private void Start()
    {
        data = new List<Tuple<string, ActiveQuestions, int>>();
    }

    public void addQuestion(ActiveQuestions question, int answer)
    {
        data.Add(new Tuple <string, ActiveQuestions, int >("player", question, answer));
    }

    public Tuple<string, ActiveQuestions, int> getLatestQuestion()
    {
        return data[(data.Count - 1)];
    }

    public int getTotalNumberOfQuestions()
    {
        return data.Count;
    }

    public int getTotalOfCorrectAnswers()
    {
        int count = 0;
        foreach(Tuple<string, ActiveQuestions, int> t in data)
        {
            if (t.Item2.getCorrectAnswer() == t.Item3)
                count++;
        }
        return count;
    }
}
