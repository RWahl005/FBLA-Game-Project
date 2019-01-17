using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnSliderChange : MonoBehaviour
{

    public Text t;
    public Slider sl;

    void Start()
    {
        t.text = sl.value  + "";
    }

    public void onChange()
    {
        t.text = sl.value + "";
    }
}
