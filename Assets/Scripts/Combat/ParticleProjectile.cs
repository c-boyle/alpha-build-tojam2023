using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleProjectile : MonoBehaviour
{
    [SerializeField] private Stats projectileStats = new();

    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out ICombatable combatable))
        {
            combatable.ReceiveAttack(projectileStats);
        }
    }
}