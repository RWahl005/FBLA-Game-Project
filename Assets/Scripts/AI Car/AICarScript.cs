using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarScript : MonoBehaviour
{

    public DataUser user;

    public Vector3 restPosition;
    public Vector3 startPosition;

    public List<GameObject> objs;

    private MainGame game;

    private bool pickedLocation;
    private bool results;
    private Vector3 selectedLane;
    private List<Vector3> locations;
    private int smartLevel;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = restPosition;
        game = Camera.main.GetComponent<MainGame>();
        pickedLocation = false;
        results = false;
        locations = new List<Vector3> { new Vector3(239.31f, 0, 0), new Vector3(245.1f, 0, 0), new Vector3(251.05f, 0, 0), new Vector3(257.2f, 0, 0) };
        smartLevel = Random.Range(19, 70);
    }

    // Update is called once per frame
    void Update()
    {
        if(game.currentMode == GameMode.Game && !pickedLocation)
        {
            results = false;
            int i = Random.Range(0, 3);
            selectedLane = locations[i];
            pickedLocation = true;
            gameObject.transform.position = startPosition;
        }
        if(game.currentMode == GameMode.Game && pickedLocation)
        {
            if(smartLevel < 30)
            {
                gameObject.transform.position += transform.forward * Time.deltaTime * 32;
                if (Mathf.Round(gameObject.transform.position.x) != Mathf.Round(selectedLane.x))
                {
                    //Calculate the direction to move in by the x.
                    float moveby = gameObject.transform.position.x < selectedLane.x ? 0.1f : -0.1f;
                    gameObject.transform.position += new Vector3(moveby, 0, 0) * Time.deltaTime * 40;
                }
            }
            else if(smartLevel >= 30 && smartLevel <= 60) //Normal Intelligence
            {
                int speed = 35;
                int spedValue = Random.Range(0, 2);
                switch (spedValue)
                {
                    case 0:
                        speed = 30;
                        break;
                    case 1:
                        speed = 35;
                        break;
                    case 2:
                        speed = 40;
                        break;
                }
                gameObject.transform.position += transform.forward * Time.deltaTime * speed;
                if (Mathf.Round(gameObject.transform.position.x) != Mathf.Round(selectedLane.x))
                {
                    //Calculate the direction to move in by the x.
                    float moveby = gameObject.transform.position.x < selectedLane.x ? 0.1f : -0.1f;
                    gameObject.transform.position += new Vector3(moveby, 0, 0) * Time.deltaTime * 40;
                }
            }
            else if(smartLevel > 60)
            {
                int speed = 36;
                gameObject.transform.position += transform.forward * Time.deltaTime * speed;
                if (Mathf.Round(gameObject.transform.position.x) != Mathf.Round(selectedLane.x))
                {
                    //Calculate the direction to move in by the x.
                    float moveby = gameObject.transform.position.x < selectedLane.x ? 0.1f : -0.1f;
                    gameObject.transform.position += new Vector3(moveby, 0, 0) * Time.deltaTime * 40;
                }
            }
        }
        if(game.currentMode == GameMode.Results && !results)
        {
            gameObject.transform.position = restPosition;
            results = true;
            pickedLocation = false;
        }
    }
}
