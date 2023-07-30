using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector]
    public Stats stats;
    public int faction;
    public TilesLogic tile;
    public int chargeTime;

    void Awake()
    {
        stats = GetComponentInChildren<Stats>();
    }

    public int GetStats(StatsEnum type)
    {
        return stats.stats[(int)type].value;
    }
}
