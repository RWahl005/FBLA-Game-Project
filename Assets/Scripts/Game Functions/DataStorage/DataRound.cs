using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRound
{
    private List<DataPlayer> dp;

    private ActiveQuestions aq;
    
    public DataRound(ActiveQuestions aq, List<DataPlayer> dp)
    {
        this.dp = dp;
        this.aq = aq;
    }

    public DataRound(ActiveQuestions aq, DataPlayer dp, DataPlayer dp2, DataPlayer dp3, DataPlayer dp4)
    {
        this.dp = new List<DataPlayer> {dp, dp2, dp3, dp4 };
        this.aq = aq;
    }

    public ActiveQuestions getQuestion()
    {
        return aq;
    }

    public List<DataPlayer> getPlayer()
    {
        return dp;
    }

    public int getCorrectAnswer()
    {
        return aq.getCorrectAnswer();
    }

    ///
    /// API Methods past here
    /// 

    ///<summary>
    /// Grab the data player class using the DataUser.
    /// </summary>
    /// <returns>
    /// Returns the DataPlayer class. Note: if no dataplayer of that datauser is found then it returns null!
    /// </returns>
    public DataPlayer getDataPlayerByUser(DataUser du)
    {
        foreach(DataPlayer d in dp)
        {
            if(d.getUser() == du)
            {
                return d;
            }
        }
        return null;
    }

    /// <summary>
    /// Get the data player class using the position
    /// </summary>
    /// <param name="position">The position. Valid number: 1-4</param>
    /// <returns>Returns the DataPlay class found. Note: if no dataplayer class if found then it returns null!</returns>
    public DataPlayer getDataPlayerByPosition(int position)
    {
        foreach(DataPlayer d in dp)
        {
            if(d.getPosition() == position)
            {
                return d;
            }
        }
        return null;
    }

    public bool isPlayerCorrect(DataUser du)
    {
        return this.getDataPlayerByUser(du).getAnswer() == this.getCorrectAnswer();
    }
}
