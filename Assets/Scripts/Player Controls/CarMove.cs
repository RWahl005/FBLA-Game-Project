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

	// Use this for initialization
	void Start () {
        movementSpeed = 30;
        game = Camera.main.GetComponent<MainGame>();

    }
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Time.deltaTime * movementSpeed; // Moves by 20 by default.
        if (game.currentMode == GameMode.Game)
        {

            if (Input.GetKey(KeyCode.W))
            {
                movementSpeed = 40;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                movementSpeed = 20;
            }
            else
            {
                movementSpeed = 30;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.position += -transform.right * Time.deltaTime * 10;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * Time.deltaTime * 10;
            }
        }
        else if (game.currentMode == GameMode.Question || game.currentMode == GameMode.Results)
        {
            movementSpeed = 40;
        }
    }
}
