using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelData
{
    public static int numberOfPeople;
    public static int numberOfPolice;
    public static int numberOfKillsNeededToWin;
    public static bool levelCompleted;

    public static void ModifyLevelDetails(Level level)
    {
        numberOfKillsNeededToWin= level.numberOfKillsNeededToWin;
        numberOfPeople = level.numberOfPeople;
        numberOfPolice = level.numberOfPolice;
        levelCompleted = level.levelCompleted;

    }

    public static void CompleteLevel()
    {
        levelCompleted = true;
    }
}
