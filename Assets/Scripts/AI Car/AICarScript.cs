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
    private GameObject selectedObj;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = restPosition;
        game = Camera.main.GetComponent<MainGame>();
        pickedLocation = false;
        results = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(game.currentMode == GameMode.Game && !pickedLocation)
        {
            results = false;
            int i = Random.Range(0, 3);
            selectedObj = objs[i];
            pickedLocation = true;
            gameObject.transform.position = startPosition;
        }
        if(game.currentMode == GameMode.Game && pickedLocation)
        {
            gameObject.transform.position += new Vector3(Vector3.MoveTowards(gameObject.transform.position, selectedObj.transform.position, Mathf.Infinity).x, 0, Vector3.MoveTowards(gameObject.transform.position, selectedObj.transform.position, Mathf.Infinity).z) * 0.05f * Time.deltaTime;
        }
        if(game.currentMode == GameMode.Results && !results)
        {
            gameObject.transform.position = restPosition;
            results = true;
            pickedLocation = false;
        }
    }
}
