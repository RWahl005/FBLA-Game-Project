using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * WindowUI API
 * Author: Ryandw11
 * Version 1.0
 */
public class ButtonPressEvent : MonoBehaviour{
    
    /*
     * Used to detect when a button is pressed for the window. use e.getId() to tell what window was interacted with.
     * Use e.getOutput() to get what button was pressed.
     * -1 = none.
     * 0 = Yes
     * 1 = no
     * 2 = ok
     * 3 = exit
     */
    public void buttonPressed(WindowUIEvent e)
    {
    }
}
