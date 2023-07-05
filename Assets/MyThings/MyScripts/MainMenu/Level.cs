using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public int level;
    public string name;
    public int numberOfPeople;
    public int numberOfPolice;
    public int numberOfKillsNeededToWin;
    public bool levelCompleted;

    public static int _level
    {
        get { return _level; }
        set { _level = value; }
    }
}
