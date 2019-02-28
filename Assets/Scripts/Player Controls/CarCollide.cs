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
                    transform.position = teleporter.transform.position;
                    GameAPI.api.callEvent(new OnResultsEvent(game.roundTime, 0));
                    GameAPI.api.callEvent(new CarHitTriggerEvent(DataUser.Player, "A")); //Call The Event Associated with this.
                    game.currentMode = GameMode.Results;
                    rm.startResults();
                    break;
                case "B":
                    if (game.currentMode != GameMode.Game) break;
                    GameAPI.api.callEvent(new CarHitTriggerEvent(DataUser.Player, "B")); //Call The Event Associated with this.
                    transform.position = teleporter.transform.position;
                    GameAPI.api.callEvent(new OnResultsEvent(game.roundTime, 1));
                    game.currentMode = GameMode.Results;
                    rm.startResults();
                    break;
                case "C":
                    if (game.currentMode != GameMode.Game) break;
                    transform.position = teleporter.transform.position;
                    GameAPI.api.callEvent(new CarHitTriggerEvent(DataUser.Player, "C")); //Call The Event Associated with this.
                    GameAPI.api.callEvent(new OnResultsEvent(game.roundTime, 2));
                    game.currentMode = GameMode.Results;
                    rm.startResults();
                    break;
                case "D":
                    if (game.currentMode != GameMode.Game) break;
                    transform.position = teleporter.transform.position;
                    GameAPI.api.callEvent(new CarHitTriggerEvent(DataUser.Player, "D")); //Call The Event Associated with this.
                    GameAPI.api.callEvent(new OnResultsEvent(game.roundTime, 3));
                    game.currentMode = GameMode.Results;
                    rm.startResults();
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
