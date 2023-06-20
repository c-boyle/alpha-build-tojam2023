using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    [SerializeField] private List<Stat> stats;
    private Dictionary<string, Stat> StatsDic
    {
        get
        {
            Dictionary<string, Stat> statsDic = new();
            foreach (var stat in stats)
            {
                statsDic[stat.Name] = stat;
            }
            return statsDic;
        }
    }

    private Dictionary<string, Action<float>> onStatChangeActions = new();

    public Dictionary<string, float> GetCopyDic()
    {
        Dictionary<string, float> copy = new();
        foreach (var stat in stats)
        {
            copy[stat.Name] = stat.Value;
        }
        return copy;
    }

    public Stats GetCopy(float modifier = 1f)
    {
        List<Stat> copy = new();
        foreach (var stat in stats)
        {
            copy.Add(new() { Name = stat.Name, Value = stat.Value * modifier });
        }
        return new Stats() { stats = copy };
    }

    public void AddStatChangedListener(string statName, Action<float> listener)
    {
        if (onStatChangeActions.TryGetValue(statName, out listener))
        {
            onStatChangeActions[statName] += listener;
        } else
        {
            onStatChangeActions[statName] = listener;
        }
    }

    public bool TryGetStatName(string statName, out float statValue)
    {
        foreach (var stat in stats)
        {
            if (stat.Name.Equals(statName))
            {
                statValue = stat.Value;
                return true;
            }
        }
        statValue = default;
        return false;
    }

    public void ApplyStats(Stats statsToApply, bool reverse = false)
    {
        ApplyStats(statsToApply.GetCopyDic(), reverse);
    }

    public void ApplyStats(Dictionary<string, float> statsToApply, bool reverse = false)
    {
        var statsDic = StatsDic;
        ChangeStats(statsDic, statsToApply, reverse);
        if (!statsToApply.TryGetValue(StatNames.DURATION, out float duration))
        {
            duration = -1f;
        }
        if (duration != -1f)
        {
            CoroutineManager.Instance.StartCoroutine(UndoStatsChangeAfterTime(statsDic, statsToApply, duration, reverse));
        }
    }

    public void ApplyToStats(Dictionary<string, float> statsToApplyTo)
    {
        ChangeStats(statsToApplyTo, GetCopyDic(), false);
    }

    private static void ChangeStats(Dictionary<string, float> statsToChange, Dictionary<string, float> statsToUse, bool reverseChanges)
    {
        foreach (var stat in statsToUse)
        {
            if (statsToChange.TryGetValue(stat.Key, out float savedStatValue))
            {
                string savedName = stat.Key.ToLower();
                if (savedName.Substring(savedName.Length - 4).Equals("mult"))
                {
                    string statToMultiplyName = stat.Key.Substring(0, savedName.Length - 5);
                    if (statsToChange.TryGetValue(statToMultiplyName, out float statToMultiplyValue))
                    {
                        if (reverseChanges)
                        {
                            statsToChange[statToMultiplyName] = statToMultiplyValue / stat.Value;
                        }
                        else
                        {
                            statsToChange[statToMultiplyName] = statToMultiplyValue * stat.Value;
                        }
                    }
                }
                else
                {
                    if (reverseChanges)
                    {
                        statsToChange[stat.Key] = savedStatValue - stat.Value;
                    }
                    else
                    {
                        statsToChange[stat.Key] = savedStatValue + stat.Value;
                    }
                }
            }
        }
    }

    private static void ChangeStats(Dictionary<string, Stat> statsToChange, Dictionary<string, float> statsToUse, bool reverseChanges)
    {
        foreach (var stat in statsToUse)
        {
            if (statsToChange.TryGetValue(stat.Key, out Stat savedStat))
            {
                string savedName = savedStat.Name.ToLower();
                if (savedName.Substring(savedName.Length - 4).Equals("mult"))
                {
                    if (statsToChange.TryGetValue(stat.Key.Substring(0, savedName.Length - 5), out Stat statToMultiply))
                    {
                        if (reverseChanges)
                        {
                            statToMultiply.Value /= stat.Value;
                        }
                        else
                        {
                            statToMultiply.Value *= stat.Value;
                        }
                    }
                }
                else
                {
                    if (reverseChanges)
                    {
                        savedStat.Value -= stat.Value;
                    }
                    else
                    {
                        savedStat.Value += stat.Value;
                    }
                }
            }
        }
    }

    private IEnumerator UndoStatsChangeAfterTime(Dictionary<string, Stat> thisStatsDic, Dictionary<string, float> statsToUse, float timer, bool reverseWasOn = false)
    {
        yield return new WaitForSeconds(timer);
        ChangeStats(thisStatsDic, statsToUse, !reverseWasOn);
    }


    [System.Serializable]
    public class Stat
    {
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField] public float Value { get; set; }
    }
}
