using System.Collections;
using System.Collections.Generic;
using System;

public class SortGameQuestions {

    public List<Question> sort(List<Question> questions, int numberOfQuestions)
    {
        List<Question> newList = questions;
            Random rnd = new Random();
            int n = newList.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Question value = newList[k];
                newList[k] = newList[n];
                newList[n] = value;
            }
        List<Question> list = new List<Question>();
        for(int i = 0; i <= numberOfQuestions; i++)
        {
            list.Add(newList[i]);
        }
        return list;
    }
	
}
