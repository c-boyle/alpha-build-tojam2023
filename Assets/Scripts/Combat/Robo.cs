using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour, ICombatable
{
    [field: SerializeField] public RoboMovement Movement { get; set; }
    [field: SerializeField] public Stats RoboStats { get; set; }
    [SerializeField] private RoboMod roboModNorth;
    [SerializeField] private RoboMod roboModSouth;
    [SerializeField] private RoboMod roboModWest;
    [SerializeField] private RoboMod roboModEast;

    /// <param name="end">True if ending use, false if beginning</param>
    public void UseRoboModSouth(bool end)
    {
        roboModSouth.Charging = !end;
    }

    /// <param name="end">True if ending use, false if beginning</param>
    public void UseRoboModNorth(bool end)
    {
        roboModNorth.Charging = !end;
    }

    /// <param name="end">True if ending use, false if beginning</param>
    public void UseRoboModEast(bool end)
    {
        roboModEast.Charging = !end;
    }

    /// <param name="end">True if ending use, false if beginning</param>
    public void UseRoboModWest(bool end)
    {
        roboModWest.Charging = !end;
    }

    public void ReceiveAttack(Stats attackStats)
    {
        RoboStats.ApplyStats(attackStats);
    }
}
