using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScoreHandler : MonoBehaviour, IEventHandler
{
    private StoreData sd;
    private MainGame game;

    private List<DataPlayer> dp;

    public List<GameObject> cars;

    // Start is called before the first frame update
    void Start()
    {
        sd = Camera.main.GetComponent<StoreData>();
        GameAPI.api.registerHandler(this);
        dp = new List<DataPlayer>();
        game = Camera.main.GetComponent<MainGame>();
    }

    [EventHandler]
    public void OnGameStart(OnRoundPlayEvent e)
    {
        dp = new List<DataPlayer>();
    }

    [EventHandler]
    public void onTriggerEvent(CarHitTriggerEvent e)
    {
        if (e.getTriggerName() == "Results" || e.getTriggerName() == "Questions" || e.getDataUser() == DataUser.Player) return;
        switch (e.getTriggerName())
        {
            case "A":
                dp.Add(new DataPlayer(e.getDataUser(), (float) game.roundTime, dp.Count + 1, 0));
                break;
            case "B":
                dp.Add(new DataPlayer(e.getDataUser(), (float)game.roundTime, dp.Count + 1, 1));
                break;
            case "C":
                dp.Add(new DataPlayer(e.getDataUser(), (float)game.roundTime, dp.Count + 1, 2));
                break;
            case "D":
                dp.Add(new DataPlayer(e.getDataUser(), (float)game.roundTime, dp.Count + 1, 3));
                break;
        }
    }

    [EventHandler]
    public void OnResults(OnResultsEvent e)
    {
        dp.Add(new DataPlayer(DataUser.Player, (float) e.getTime(), dp.Count + 1, e.getAnswer()));
        fillInRemainingPlayerData(e.getTime());
        sd.addRound(new DataRound(game.getCurrentQuestion(), dp));

        ResultsManager rm = Camera.main.GetComponent<ResultsManager>();
        game.currentMode = GameMode.Results;
        rm.startResults();
    }

    public List<DataPlayer> getData()
    {
        return dp;
    }

    public void fillInRemainingPlayerData(double time)
    {
        if (!isAIOne())
        {
            int rangeMin = Mathf.CeilToInt(dp[dp.Count - 1].getTime());
            int rangeMax = rangeMin + Random.Range(1, 3);
            int answer = cars[0].GetComponent<AICarScript>().getAnswer();

            dp.Add(new DataPlayer(DataUser.AICar1, (float)time + Random.Range(rangeMin, rangeMax), dp.Count + 1, answer));
        }

        if (!isAITwo())
        {
            int rangeMin = Mathf.CeilToInt(dp[dp.Count - 1].getTime());
            int rangeMax = rangeMin + Random.Range(1, 3);
            int answer = cars[1].GetComponent<AICarScript>().getAnswer();

            dp.Add(new DataPlayer(DataUser.AICar2, (float)time + Random.Range(rangeMin, rangeMax), dp.Count + 1, answer));
        }

        if (!isAIThree())
        {
            int rangeMin = Mathf.CeilToInt(dp[dp.Count - 1].getTime());
            int rangeMax = rangeMin + Random.Range(1, 3);
            int answer = cars[2].GetComponent<AICarScript>().getAnswer();

            dp.Add(new DataPlayer(DataUser.AICar3, (float)time + Random.Range(rangeMin, rangeMax), dp.Count + 1, answer));
        }
    }

    private bool isAIOne()
    {
        bool found = false;
        foreach (DataPlayer d in dp)
        {
            if (d.getUser() == DataUser.AICar1)
            {
                found = true;
                break;
            }
        }
        return found;
    }

    private bool isAITwo()
    {
        bool found = false;
        foreach (DataPlayer d in dp)
        {
            if (d.getUser() == DataUser.AICar2)
            {
                found = true;
                break;
            }
        }
        return found;
    }

    private bool isAIThree()
    {
        bool found = false;
        foreach (DataPlayer d in dp)
        {
            if (d.getUser() == DataUser.AICar3)
            {
                found = true;
                break;
            }
        }
        return found;
    }
}
