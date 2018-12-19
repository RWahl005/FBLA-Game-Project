using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("next", 0.2f);
        
	}

    void next()
    {
        Camera.main.GetComponent<QuestionManager>().nextQuestion();
    }
	
}
