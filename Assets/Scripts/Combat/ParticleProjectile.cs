using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script for projectiles that come from a particle system.
/// </summary>

public class ParticleProjectile : MonoBehaviour {
  [SerializeField] private RoboMod owner;
  [SerializeField] private Stats projectileStats = new();

  private void OnParticleCollision(GameObject other) {
    Debug.Log("Particle collision");
    if (other.TryGetComponent(out ICombatable combatable) && other.TryGetComponent(out Rigidbody2D rb) && rb != owner.Owner.Movement.Rigidbody) {
      combatable.ReceiveAttack(projectileStats);
    }
  }
}
