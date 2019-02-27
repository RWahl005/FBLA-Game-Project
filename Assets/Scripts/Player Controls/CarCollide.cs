using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollide : MonoBehaviour {

    /// <summary>
    /// When the car collides on the triggers.
    /// </summary>

    private MainGame game;
    private StoreData sd;
    private ResultsManager rm;
    private QuestionManager qm;

    public GameObject teleporter;

    private void Start()
    {
        game = Camera.main.GetComponent<MainGame>();
        sd = Camera.main.GetComponent<StoreData>();
        rm = Camera.main.GetComponent<ResultsManager>();
        qm = Camera.main.GetComponent<QuestionManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<TriggerZone>() != null)
        {
            switch (other.gameObject.GetComponent<TriggerZone>().name)
            {
                case "A":
                    if (game.currentMode != GameMode.Game) break;
                    //sd.addQuestion(game.getCurrentQuestion(), 0);
                    sd.addRound(new DataRound(game.getCurrentQuestion(), new DataPlayer(DataUser.Player, 0, 0, 0), null, null, null)); //TODO: FIX THIS SYSTEM TO SUPPORT SINGLEPLAYER AI
                    rm.startResults();
                    transform.position = teleporter.transform.position;
                    GameAPI.api.callEvent(new CarHitTriggerEvent(DataUser.Player, "A")); //Call The Event Associated with this.
                    game.currentMode = GameMode.Results;
                    GameAPI.api.callEvent(new OnResultsEvent());
                    break;
                case "B":
                    if (game.currentMode != GameMode.Game) break;
                    // sd.addQuestion(game.getCurrentQuestion(), 1);
                    sd.addRound(new DataRound(game.getCurrentQuestion(), new DataPlayer(DataUser.Player, 0, 0, 1), null, null, null)); //TODO: FIX THIS SYSTEM TO SUPPORT SINGLEPLAYER AI
                    rm.startResults();
                    GameAPI.api.callEvent(new CarHitTriggerEvent(DataUser.Player, "B")); //Call The Event Associated with this.
                    transform.position = teleporter.transform.position;
                    game.currentMode = GameMode.Results;
                    GameAPI.api.callEvent(new OnResultsEvent());
                    break;
                case "C":
                    if (game.currentMode != GameMode.Game) break;
                    //sd.addQuestion(game.getCurrentQuestion(), 2);
                    sd.addRound(new DataRound(game.getCurrentQuestion(), new DataPlayer(DataUser.Player, 0, 0, 2), null, null, null)); //TODO: FIX THIS SYSTEM TO SUPPORT SINGLEPLAYER AI
                    rm.startResults();
                    transform.position = teleporter.transform.position;
                    GameAPI.api.callEvent(new CarHitTriggerEvent(DataUser.Player, "C")); //Call The Event Associated with this.
                    game.currentMode = GameMode.Results;
                    GameAPI.api.callEvent(new OnResultsEvent());
                    break;
                case "D":
                    if (game.currentMode != GameMode.Game) break;
                    //sd.addQuestion(game.getCurrentQuestion(), 3);
                    sd.addRound(new DataRound(game.getCurrentQuestion(), new DataPlayer(DataUser.Player, 0, 0, 3), null, null, null)); //TODO: FIX THIS SYSTEM TO SUPPORT SINGLEPLAYER AI
                    rm.startResults();
                    transform.position = teleporter.transform.position;
                    GameAPI.api.callEvent(new CarHitTriggerEvent(DataUser.Player, "D")); //Call The Event Associated with this.
                    GameAPI.api.callEvent(new OnResultsEvent());
                    game.currentMode = GameMode.Results;
                    break;
                case "Results":
                    if (game.currentMode != GameMode.Results) break;
                    rm.endResults();
                    game.currentMode = GameMode.Question;
                    GameAPI.api.callEvent(new CarHitTriggerEvent(DataUser.Player, "Results")); //Call The Event Associated with this.
                    transform.position = teleporter.transform.position;
                    qm.nextQuestion();
                    break;
                case "Question":
                    if (game.currentMode != GameMode.Question) break;
                    game.currentMode = GameMode.Game;
                    GameAPI.api.callEvent(new CarHitTriggerEvent(DataUser.Player, "Question")); //Call The Event Associated with this.
                    GameAPI.api.callEvent(new OnRoundPlayEvent());
                    transform.position = teleporter.transform.position;
                    qm.endQuestion();
                    break;
            }
        }
    }
}
