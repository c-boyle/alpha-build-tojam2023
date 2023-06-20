using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for all classes that can engage in combat.
/// </summary>

public interface ICombatable
{
    public void ReceiveAttack(Stats attackStats);
}
