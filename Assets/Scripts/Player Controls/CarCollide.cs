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
                    sd.addQuestion(game.getCurrentQuestion(), 0);
                    rm.startResults();
                    transform.position = teleporter.transform.position;
                    game.currentMode = GameMode.Results;
                    break;
                case "B":
                    if (game.currentMode != GameMode.Game) break;
                    sd.addQuestion(game.getCurrentQuestion(), 1);
                    rm.startResults();
                    transform.position = teleporter.transform.position;
                    game.currentMode = GameMode.Results;
                    break;
                case "C":
                    if (game.currentMode != GameMode.Game) break;
                    sd.addQuestion(game.getCurrentQuestion(), 2);
                    rm.startResults();
                    transform.position = teleporter.transform.position;
                    game.currentMode = GameMode.Results;
                    break;
                case "D":
                    if (game.currentMode != GameMode.Game) break;
                    sd.addQuestion(game.getCurrentQuestion(), 3);
                    rm.startResults();
                    transform.position = teleporter.transform.position;
                    game.currentMode = GameMode.Results;
                    break;
                case "Results":
                    if (game.currentMode != GameMode.Results) break;
                    rm.endResults();
                    game.currentMode = GameMode.Question;
                    transform.position = teleporter.transform.position;
                    qm.nextQuestion();
                    break;
                case "Question":
                    if (game.currentMode != GameMode.Question) break;
                    game.currentMode = GameMode.Game;
                    transform.position = teleporter.transform.position;
                    qm.endQuestion();
                    break;
            }
        }
    }
}
