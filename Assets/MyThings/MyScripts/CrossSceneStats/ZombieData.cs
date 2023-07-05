using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieData
{
    public int survivalTime { get; private set; }
    public int defence { get; private set; }
    public float speed { get; private set; }
    public int attack { get; private set; }

    public ZombieData(int survivalTime, int defence, float speed, int attack)
    {
        this.survivalTime = survivalTime;
        this.defence = defence;
        this.speed = speed;
        this.attack = attack;
    }

    public static ZombieData zombieData = new ZombieData(5, 5, 1.5f, 2);

    public static void IncreaseSurvivalTime(int amount)
    {
       zombieData.survivalTime += amount;
    }

    public static void IncreaseDefence(int amount)
    {
        zombieData.defence += amount;
    }

    public static void IncreaseSpeed(float amount)
    {
        zombieData.speed += amount;
    }

    public static void IncreaseAttack(int amount)
    {
        zombieData.attack += amount;
    }

}
