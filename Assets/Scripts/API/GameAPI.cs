using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAPI : MonoBehaviour
{

    public static APIHandler api = new APIHandler();

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }



}
