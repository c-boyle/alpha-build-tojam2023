using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour, ICombatable
{
    [field: SerializeField] public RoboMovement Movement { get; set; }
    [field: SerializeField] public Stats RoboStats { get; set; } = new();
    [SerializeField] private RoboMod roboModSouth;
    [SerializeField] private RoboMod roboModNorth;
    [SerializeField] private RoboMod roboModWest;
    [SerializeField] private RoboMod roboModEast;

    private void Start()
    {
        if (roboModSouth != null)
        {
            roboModSouth.Owner = this;
        }
        if (roboModNorth != null)
        {
            roboModNorth.Owner = this;
        }
        if (roboModWest != null)
        {
            roboModWest.Owner = this;
        }
        if (roboModEast != null)
        {
            roboModEast.Owner = this;
        }
    }

    /// <param name="end">True if ending use, false if beginning</param>
    public void UseRoboModSouth(bool end)
    {
        if (roboModSouth != null)
        {
            roboModSouth.Owner = this;
            roboModSouth.Charging = !end;
        }
    }

    /// <param name="end">True if ending use, false if beginning</param>
    public void UseRoboModNorth(bool end)
    {
        if (roboModNorth != null)
        {
            roboModNorth.Owner = this;
            roboModNorth.Charging = !end;
        }
    }

    /// <param name="end">True if ending use, false if beginning</param>
    public void UseRoboModEast(bool end)
    {
        if (roboModEast != null)
        {
            roboModEast.Owner = this;
            roboModEast.Charging = !end;
        }
    }

    /// <param name="end">True if ending use, false if beginning</param>
    public void UseRoboModWest(bool end)
    {
        if (roboModWest != null)
        {
            roboModWest.Owner = this;
            roboModWest.Charging = !end;
        }
    }

    public void ReceiveAttack(Stats attackStats)
    {
        RoboStats.ApplyStats(attackStats);
    }
}
