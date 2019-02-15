using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreData : MonoBehaviour {
    /// <summary>
    /// Stores the data temporarly
    /// TODO: When the results screen is about to be loaded save this in a non-destoryable object and send it over.
    /// </summary>

    private List<DataRound> dr;

    void Start()
    {
        dr = new List<DataRound>();
    }

    ///
    /// Begin of the API section of the code.
    /// 

     ///<summary>
     /// Adds a round to the data storer. (Takes DataRound)
     /// </summary>
    public void addRound(DataRound dr)
    {
        this.dr.Add(dr);
    }

    /// <summary>
    /// Grab all of the stored data rounds.
    /// </summary>
    /// <returns>Returns the data rounds.</returns>
    public List<DataRound> getDataRounds()
    {
        return dr;
    }

    /// <summary>
    /// Get the latest data round.
    /// </summary>
    /// <returns>Gets the latest data round.</returns>
    public DataRound getLatestRound()
    {
        return dr[dr.Count - 1];
    }

    /// <summary>
    /// Gets the total of correct answers for the user specified.
    /// </summary>
    /// <param name="du">The datauser you want data for.</param>
    /// <returns>The total of correct answwers.</returns>
    public int getTotalCorrect(DataUser du)
    {
        int count = 0;
        foreach(DataRound d in dr)
        {
            if (d.isPlayerCorrect(du))
            {
                count++;
            }
        }
        return count;
    }

    /// <summary>
    /// Get the total number of questions that were in the game.
    /// </summary>
    /// <returns>Returns the intager count.</returns>
    public int getTotalNumberOfQuestions()
    {
        return dr.Count;
    }

}
