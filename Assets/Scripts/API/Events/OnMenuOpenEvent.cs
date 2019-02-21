using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMenuOpenEvent
{
    private Menus menu;

   public OnMenuOpenEvent(Menus menu)
    {
        this.menu = menu;
    }

    public Menus getMenu()
    {
        return menu;
    }
}
