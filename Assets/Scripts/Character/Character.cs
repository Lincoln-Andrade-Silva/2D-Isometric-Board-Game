using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector]
    public Stats stats;

    void Awake()
    {
        stats = GetComponent<Stats>();
    }
}
