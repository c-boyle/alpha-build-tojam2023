using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour, ICombatable
{
    [field: SerializeField] public Stats RoboStats { get; set; }

    public void UseRoboModNorth()
    {

    }

    public void UseRoboModEast()
    {
        
    }

    public void UseRoboModWest()
    {

    }

    public void ReceiveAttack(Stats attackStats)
    {
        RoboStats.ApplyStats(attackStats);
    }
}
