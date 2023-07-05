using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GoldManager
{
    public static int gold { get; private set; }

    public static void ModifyGoldAmount(int value)
    {
        gold = value;
    }

    public static void AddGold(int amount)
    {
        gold += amount;
    }
}
