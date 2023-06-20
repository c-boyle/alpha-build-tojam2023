using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour, ICombatable
{
    [SerializeField] private UnityEngine.InputSystem.PlayerInput owner;
    [SerializeField] private int health = 1;

    public void ReceiveAttack(Stats attackStats)
    {
        if (attackStats.TryGetStatName("health", out float statValue))
        {
            health += (int)statValue;
            if (health <= 0)
            {
                Destroy(owner.gameObject);
            }
        }
    }
}
