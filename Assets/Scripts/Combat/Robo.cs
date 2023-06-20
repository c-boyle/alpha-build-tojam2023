using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour, ICombatable
{
    [field: SerializeField] public RoboMovement Movement { get; set; }
    [field: SerializeField] public Stats RoboStats { get; set; } = new();
    [field: SerializeField] public RoboMod RoboModSouth { get; set; }
    [field: SerializeField] public RoboMod RoboModNorth { get; set; }
    [field: SerializeField] public RoboMod RoboModEast { get; set; }
    [field: SerializeField] public RoboMod RoboModWest { get; set; }
    [field: SerializeField] public Transform RoboModSouthPos { get; set; }
    [field: SerializeField] public Transform RoboModNorthPos { get; set; }
    [field: SerializeField] public Transform RoboModEastPos { get; set; }
    [field: SerializeField] public Transform RoboModWestPos { get; set; }

    private void Start()
    {
        if (RoboModSouth != null)
        {
            RoboModSouth.Owner = this;
        }
        if (RoboModNorth != null)
        {
            RoboModNorth.Owner = this;
        }
        if (RoboModWest != null)
        {
            RoboModWest.Owner = this;
        }
        if (RoboModEast != null)
        {
            RoboModEast.Owner = this;
        }
        Movement.Owner = this;
    }

    /// <param name="end">True if ending use, false if beginning</param>
    public void UseRoboModSouth(bool end)
    {
        if (RoboModSouth != null)
        {
            RoboModSouth.Charging = !end;
        }
    }

    /// <param name="end">True if ending use, false if beginning</param>
    public void UseRoboModNorth(bool end)
    {
        if (RoboModNorth != null)
        {
            RoboModNorth.Charging = !end;
        }
    }

    /// <param name="end">True if ending use, false if beginning</param>
    public void UseRoboModEast(bool end)
    {
        if (RoboModEast != null)
        {
            RoboModEast.Charging = !end;
        }
    }

    /// <param name="end">True if ending use, false if beginning</param>
    public void UseRoboModWest(bool end)
    {
        if (RoboModWest != null)
        {
            RoboModWest.Charging = !end;
        }
    }

    public void ReceiveAttack(Stats attackStats)
    {
        RoboStats.ApplyStats(attackStats);
    }
}
