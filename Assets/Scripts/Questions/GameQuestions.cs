using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuestions
{

    private List<ActiveQuestions> aques = new List<ActiveQuestions>();

    public GameQuestions(List<Question> ques)
    {
        foreach (Question q in ques)
        {
            aques.Add(new ActiveQuestions(q));
        }
    }

    public List<ActiveQuestions> getActiveQuestions()
    {
        return aques;
    }

}
