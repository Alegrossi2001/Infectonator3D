using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public static Gold Instance { get; private set; }
    private int gold;

    private void Awake()
    {
        gold = GoldManager.gold;
        Instance = this;
    }

    public void AddGold(int amount)
    {
        gold += amount;
        GoldManager.ModifyGoldAmount(gold);
    }

    public void RemoveGold(int amount)
    {
        gold -= amount;
        GoldManager.ModifyGoldAmount(gold);
    }

    public int GetGold()
    {
        return gold;
    }

}
