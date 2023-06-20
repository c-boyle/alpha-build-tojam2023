using MyBox;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboMod : MonoBehaviour, ICombatable
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool canHoldActivatedAttack;
    [SerializeField] private bool maxChargeTimeCopiesAnimationLength = true;
    [SerializeField][ConditionalField(nameof(maxChargeTimeCopiesAnimationLength), inverse:true)] private float maxChargeSeconds = 1f;

    [SerializeField] private Stats userEffects = new();
    [SerializeField] private Stats defensiveStats = new();
    [SerializeField] private Stats passiveContactStats = new();
    [SerializeField] private Stats attackContactStats = new();

    public Robo Owner { get; set; }

    private DateTime chargeStartTime = DateTime.MinValue;
    private DateTime chargeStopTime = DateTime.MinValue;
    private bool _charging = false;

    private bool activated = false;

    private AnimationClip chargingClip = null;
    private AnimationClip activatingClip = null;

    private float MaxChargeSeconds
    {
        get
        {
            return maxChargeTimeCopiesAnimationLength && chargingClip != null ? chargingClip.length : maxChargeSeconds;
        }
    }

    public bool Charging
    {
        get
        {
            return _charging;
        }
        set
        {
            if (MaxChargeSeconds <= 0f)
            {
                if (value)
                {
                    animator.SetTrigger("instant_charge");
                }
                _charging = value;
                return;
            }
            bool chargingStarted = value && !_charging;
            if (chargingStarted && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                chargeStartTime = DateTime.Now;
                animator.SetBool("charging", true);
            }
            bool chargeStopped = !value && _charging;
            if (chargeStopped)
            {
                chargeStopTime = DateTime.Now;
                animator.SetBool("charging", false);
            }
            _charging = value;
        }
    }

    private void Start()
    {
        foreach (var clip in animator.runtimeAnimatorController.animationClips)
        {
            string clipName = clip.name.ToLower();
            if (clipName.Contains("charging"))
            {
                chargingClip = clip;
            } else if (clipName.Contains("activating"))
            {
                activatingClip = clip;
            }
        }
        animator.SetBool("has_activating", activatingClip.length != 0f);
    }

    private void Update()
    {
        bool isInActiveState = animator.GetCurrentAnimatorStateInfo(0).IsName("Activated");
        if (isInActiveState)
        {
            if ((canHoldActivatedAttack && Charging && !activated) || !activated)
            {
                activated = true;
                Owner.RoboStats.ApplyStats(userEffects);
            }
        } else if (activated)
        {
            activated = canHoldActivatedAttack && Charging;
            Owner.RoboStats.ApplyStats(userEffects, !activated);
            if (activated)
            {
                animator.Play("Base Layer.Activated", 0, 0f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.TryGetComponent<ICombatable>(out var combatable))
        {
            var currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (currentStateInfo.IsName("Activated"))
            {
                OnAttackContact(collision, combatable);
            } else
            {
                OnPassiveContact(collision, combatable);
            }
        }
    }

    private float GetPercentCharged()
    {
        float percentCharged = 1f;
        if (MaxChargeSeconds > 0f)
        {
            percentCharged = ((float)(chargeStopTime - chargeStartTime).TotalSeconds) / MaxChargeSeconds;
        }
        return percentCharged;
    }

    private void OnAttackContact(Collision2D collision, ICombatable combatable)
    {
        float percentCharged = GetPercentCharged();
        var attackStats = percentCharged == 1f ? attackContactStats : attackContactStats.GetCopy(Mathf.Sqrt(percentCharged));
        if (attackStats.TryGetStatName(StatNames.KNOCKBACK, out float knockback))
        {
            collision.rigidbody.velocity = collision.GetContact(0).normal * -knockback;
        }
        combatable.ReceiveAttack(attackStats);
    }

    private void OnPassiveContact(Collision2D collision, ICombatable combatable)
    {
        if (combatable is RoboMod roboMod)
        {
            var currentStateInfo = roboMod.animator.GetCurrentAnimatorStateInfo(0);
            if (!currentStateInfo.IsName("Activated"))
            {
                roboMod.ReceiveAttack(passiveContactStats);
            }
        } else
        {
            combatable.ReceiveAttack(passiveContactStats);
        }
    }

    public void ReceiveAttack(Stats attackStats)
    {
        var statsCopy = attackStats.GetCopyDic();
        this.defensiveStats.ApplyToStats(statsCopy);
        Owner.RoboStats.ApplyStats(statsCopy);
    }
}
