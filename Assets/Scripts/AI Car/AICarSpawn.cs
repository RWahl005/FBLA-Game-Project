using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarSpawn : MonoBehaviour {

    public GameObject pfCar;
    public GameObject pfCar2;
    public GameObject pfCar3;
    public GameObject pfCar4;
    Transform tf;
    public int ranRange = 500;


    // Use this for initialization
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.GetComponent<MainGame>().isPaused)
            return;
        int num = Random.Range(1, ranRange);
        if (num == 30)
        {
            int nums = Random.Range(1, 5);
            GameObject obj;
            switch (nums)
            {
                case 1:
                    obj = Instantiate(pfCar, tf.position, Quaternion.identity);
                    break;
                case 2:
                    obj = Instantiate(pfCar2, tf.position, Quaternion.identity);
                    break;
                case 3:
                    obj = Instantiate(pfCar3, tf.position, Quaternion.identity);
                    break;
                case 4:
                    obj = Instantiate(pfCar4, tf.position, Quaternion.identity);
                    break;
                default:
                    obj = Instantiate(pfCar, tf.position, Quaternion.identity);
                    break;
            }
           
            obj.transform.rotation = tf.rotation;
            Destroy(obj, 17); //17 is time in seconds till the car is destroyed.
        }
    }

}
