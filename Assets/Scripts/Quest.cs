using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public string title;
    public string description;
    public bool isCompleted = false;
    public System.Func<PlayerScript, bool> condition;

    public void Check(PlayerScript player)
    {
        if (!isCompleted && condition(player))
        {
            isCompleted = true;
            Debug.Log("Äù½ºÆ® ¿Ï·á: " + title);
        }
    }
}
