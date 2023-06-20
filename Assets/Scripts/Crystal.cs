using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour, ICombatable
{
    [SerializeField] private UnityEngine.InputSystem.PlayerInput owner;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int health = 1;

    private AnimationClip _deathClip;
    private AnimationClip DeathClip
    {
        get
        {
            if (_deathClip == null)
            {
                foreach (var clipInfo in animator.GetCurrentAnimatorClipInfo(0))
                {
                    if (clipInfo.clip.name.Contains("death"))
                    {
                        _deathClip = clipInfo.clip;
                    }
                }
            }
            return _deathClip;
        }
    }

    public void ReceiveAttack(Stats attackStats)
    {
        if (attackStats.TryGetStatName(StatNames.HEALTH, out float statValue))
        {
            health += (int)statValue;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.velocity.magnitude >= 3f)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("die");
        StartCoroutine(DieAfterDelay(DeathClip.length));
    }

    private IEnumerator DieAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(owner.gameObject);
    }
}
