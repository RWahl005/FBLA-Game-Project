using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour {

    /// <summary>
    /// Controls the car.
    /// TODO: Replace hard coding with controls Library.
    /// </summary>

    public int movementSpeed;

    private MainGame game;
    private KeyHandler kh;

	// Use this for initialization
	void Start () {
        movementSpeed = 30;
        game = Camera.main.GetComponent<MainGame>();
        kh = Camera.main.GetComponent<KeyHandler>();

    }
	
	// Update is called once per frame
	void Update () {
        if (game.isPaused)
            return;
        transform.position += transform.forward * Time.deltaTime * movementSpeed; // Moves by 20 by default.
        if (game.currentMode == GameMode.Game)
        {

            if (Input.GetKey(kh.getKey("speedup")))
            {
                movementSpeed = 45;
            }
            else if (Input.GetKey(kh.getKey("slowdown")))
            {
                movementSpeed = 25;
            }
            else
            {
                movementSpeed = 35;
            }

            if (Input.GetKey(kh.getKey("moveleft")))
            {
                transform.position += -transform.right * Time.deltaTime * 10;
            }
            else if (Input.GetKey(kh.getKey("moveright")))
            {
                transform.position += transform.right * Time.deltaTime * 10;
            }
        }
        else if (game.currentMode == GameMode.Question || game.currentMode == GameMode.Results)
        {
            movementSpeed = 50; //Speed up the cars again.
        }
    }
}
