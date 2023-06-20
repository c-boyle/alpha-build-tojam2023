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
    [SerializeField][ConditionalField(nameof(maxChargeTimeCopiesAnimationLength))] private float maxChargeSeconds = 1f;

    [SerializeField] private Stats userEffects = new();
    [SerializeField] private Stats defensiveStats = new();
    [SerializeField] private Stats passiveContactStats = new();
    [SerializeField] private Stats attackContactStats = new();

    private Robot owner;

    private DateTime chargeStartTime = DateTime.MinValue;
    private DateTime chargeStopTime = DateTime.MinValue;
    private bool _charging = false;

    private bool activated = false;

    private bool haveCheckedChargingClip = false;
    private AnimationClip _chargingClip = null;
    private AnimationClip ChargingClip
    {
        get
        {
            bool chargingTimeIsZero = !maxChargeTimeCopiesAnimationLength && maxChargeSeconds <= 0f;
            if (chargingTimeIsZero)
            {
                return null;
            }
            if (!haveCheckedChargingClip)
            {
                foreach (var clip in animator.runtimeAnimatorController.animationClips)
                {
                    if (clip.name.ToLower().Contains("charging"))
                    {
                        _chargingClip = clip;
                    }
                }
                haveCheckedChargingClip = true;
            }
            return _chargingClip;
        }
    }

    private float MaxChargeSeconds
    {
        get
        {
            return maxChargeTimeCopiesAnimationLength ? ChargingClip.length : maxChargeSeconds;
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
                return;
            }
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                bool chargingStarted = value && !_charging;
                if (chargingStarted)
                {
                    chargeStartTime = DateTime.Now;
                }
                bool chargeStopped = !value && _charging;
                if (chargeStopped)
                {
                    chargeStopTime = DateTime.Now;
                }
                _charging = value;
                animator.SetBool("charging", _charging);
            }
        }
    }

    private void Init(Robot owner)
    {
        this.owner = owner;
    }

    private void Update()
    {
        bool isInActiveState = animator.GetCurrentAnimatorStateInfo(0).IsName("Activated");
        if (!activated && isInActiveState)
        {
            activated = true;
            owner.RoboStats.ApplyStats(userEffects);
        } else if (activated && !isInActiveState)
        {
            activated = false;
            owner.RoboStats.ApplyStats(userEffects, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.TryGetComponent<ICombatable>(out var combatable))
        {
            var currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (currentStateInfo.IsName("Activated"))
            {
                OnAttackContact(combatable);
            } else
            {
                OnPassiveContact(combatable);
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

    private void OnAttackContact(ICombatable combatable)
    {
        float percentCharged = GetPercentCharged();
        if (percentCharged == 1f)
        {
            combatable.ReceiveAttack(attackContactStats);
        } else
        {
            combatable.ReceiveAttack(attackContactStats.GetCopy(Mathf.Sqrt(percentCharged)));
        }
    }

    private void OnPassiveContact(ICombatable combatable)
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
        owner.RoboStats.ApplyStats(statsCopy);

    }
}
