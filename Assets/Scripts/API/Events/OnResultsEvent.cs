using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnResultsEvent
{
    private double time;
    private int answer;

    public OnResultsEvent(double time, int answer)
    {
        this.time = time;
        this.answer = answer;
    }

    public double getTime()
    {
        return time;
    }

    public int getAnswer()
    {
        return answer;
    }
}
