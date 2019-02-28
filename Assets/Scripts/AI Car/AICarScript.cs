using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarScript : MonoBehaviour
{
    // The DataUser that the AI car is assigned.
    public DataUser user;

    // The position the car is reset to when not in play.
    public Vector3 restPosition;
    // Where the car starts on the road.
    public Vector3 startPosition;

    /*
     * Private variable declaration.
     */

    // The instance of the main game.
    private MainGame game;
    // If the computer picked a lane to be in.
    private bool pickedLocation;
    // 
    private bool results;
    // The vector3 location of the selected lane.
    private Vector3 selectedLane;
    // The possible lanes it can go into.
    private List<Vector3> locations;
    // How smart the car is.
    private int smartLevel;
    // How much time before it decides it's next action.
    private double time = 0.5;
    //The speed
    private int speed = 35;

    /*
     * Start and Update methods.
     */

    // Start is called before the first frame update
    void Start()
    {
        // Move the ai cars off screen at the start.
        gameObject.transform.position = restPosition;
        // Grabs the MainGame script.
        game = Camera.main.GetComponent<MainGame>();
        //Sets the default variables.
        pickedLocation = false;
        results = false;
        locations = new List<Vector3> { new Vector3(239.31f, 0, 0), new Vector3(245.1f, 0, 0), new Vector3(251.05f, 0, 0), new Vector3(257.2f, 0, 0) };
        // Picks the smartness level.
        smartLevel = Random.Range(19, 70);
    }

    // Update is called once per frame
    void Update()
    {
        // If the game is paused (esc screen)
        if (game.isPaused) return;

        // If the AI Car is in the game and has not picked a letter yet.
        if(game.currentMode == GameMode.Game && !pickedLocation)
        {
            results = false;
            // Grabs a random number from 0 - 3
            int i = Random.Range(0, 4);
            // Sets the selected lane from the list of locations
            selectedLane = locations[i];
            // Confirms that it has picked an object.
            pickedLocation = true;
            // Moves the AI Car to it's start position.
            gameObject.transform.position = startPosition;
        }
        // If the AI Car is in the game and has picked a letter.
        if(game.currentMode == GameMode.Game && pickedLocation)
        {
            // If the car is stupid.
            if(smartLevel < 30)
            {
                // Sets the speed to 32 only. (Fix?)
                gameObject.transform.position += transform.forward * Time.deltaTime * 32;
                //Moves the the lane desired if not already in it.
                if (Mathf.Round(gameObject.transform.position.x) != Mathf.Round(selectedLane.x))
                {
                    //Calculate the direction to move in by the x.
                    float moveby = gameObject.transform.position.x < selectedLane.x ? 0.1f : -0.1f;
                    gameObject.transform.position += new Vector3(moveby, 0, 0) * Time.deltaTime * 40;
                }
            }
            // If the car is normal smart.
            else if(smartLevel >= 30 && smartLevel <= 65) //Normal Intelligence
            {
                // Counts the clock down.   
                time -= Time.deltaTime;
                // If the timer is less than zero.
                if(time < 0)
                {
                    // Select the new speed.
                    speed = selectSpeed();
                }
                // Move the gameobject bu the speed.
                gameObject.transform.position += transform.forward * Time.deltaTime * speed;
                // Go to it's proper lane.
                if (Mathf.Round(gameObject.transform.position.x) != Mathf.Round(selectedLane.x))
                {
                    //Calculate the direction to move in by the x.
                    float moveby = gameObject.transform.position.x < selectedLane.x ? 0.1f : -0.1f;
                    gameObject.transform.position += new Vector3(moveby, 0, 0) * Time.deltaTime * 40;
                }
            }
            // Super smart.
            else if(smartLevel > 65)
            {
                // Sets the smart speed.
                speed = 36;
                gameObject.transform.position += transform.forward * Time.deltaTime * speed;
                if (Mathf.Round(gameObject.transform.position.x) != Mathf.Round(selectedLane.x))
                {
                    //Calculate the direction to move in by the x.
                    float moveby = gameObject.transform.position.x < selectedLane.x ? 0.1f : -0.1f;
                    gameObject.transform.position += new Vector3(moveby, 0, 0) * Time.deltaTime * 40;
                }
            }
        }
        // If the round turns to results.
        if(game.currentMode == GameMode.Results && !results)
        {
            // Sets the curret postion to the rest position.
            gameObject.transform.position = restPosition;
            results = true;
            pickedLocation = false;
        }
    }

    /*
     * Select a speed at random for the car.
     */
    private int selectSpeed()
    {
        int speed = 35;
        int spedValue = Random.Range(0, 3);
        switch (spedValue)
        {
            case 0:
                speed = 29;
                break;
            case 1:
                speed = 34;
                break;
            case 2:
                speed = 40;
                break;
        }
        time = 0.5;
        return speed;
    }

    /*
     * Public API Methods
     */

    public DataUser getUser()
    {
        return user;
    }

    public int getSmart()
    {
        return smartLevel;
    }

    public int getAnswer()
    {
        return locations.IndexOf(selectedLane);
    }
}
