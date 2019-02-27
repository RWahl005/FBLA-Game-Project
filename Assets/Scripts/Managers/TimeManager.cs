using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour, IEventHandler
{
    private MainGame game;
    private bool update;

    // Start is called before the first frame update
    void Start()
    {
        game = Camera.main.GetComponent<MainGame>();
        update = false;
        GameAPI.api.registerHandler(this);
    }

    void Update()
    {
        if (update && !game.isPaused)
        {
            game.roundTime += Time.deltaTime;
        }
    }

    [EventHandler]
    public void onGameStart(OnRoundPlayEvent e)
    {
        update = true;
        game.roundTime = 0;
    }

    [EventHandler]
    public void onResultsStart(OnResultsEvent e)
    {
        update = false;
    }
}
