using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// SINGLE PLAYER ONLY
/// API Event class for when a car (AI or Player) hits a trigger zone.  
/// The trigger zones include: Question, Results, A, B, C, and D.  
/// </summary>
public class CarHitTriggerEvent
{
    private DataUser user;
    private string triggerName;

    public CarHitTriggerEvent(DataUser user, string triggerName)
    {
        this.user = user;
        this.triggerName = triggerName;
    }

    /// <summary>
    /// Get the DataUser
    /// </summary>
    /// <returns>The data user the event fires for.</returns>
    public DataUser getDataUser()
    {
        return user;
    }

    /// <summary>
    /// Get the trigger that was hit.
    /// </summary>
    /// <returns>The trigger that was hit.</returns>
    public string getTriggerName()
    {
        return triggerName;
    }
}
