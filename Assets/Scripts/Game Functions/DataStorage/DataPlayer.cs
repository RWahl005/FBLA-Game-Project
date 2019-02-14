using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPlayer
{
    private DataUser du;
    private float time;
    private int position;
    private int answer;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="du"></param>
    /// <param name="time"></param>
    /// <param name="position">Valid places: 1-4</param>
    public DataPlayer(DataUser du, float time, int position, int answer)
    {
        this.du = du;
        this.time = time;
        this.position = position;
        this.answer = answer;
    }

    public DataUser getUser()
    {
        return du;
    }

    public float getTime()
    {
        return time;
    }

    public int getPosition()
    {
        return position;
    }

    public int getAnswer()
    {
        return answer;
    }

   
}
