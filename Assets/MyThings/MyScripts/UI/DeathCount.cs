using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCount : MonoBehaviour
{
    private TextMeshProUGUI deathText;
    private int deathCount;

    private void Awake()
    {
        deathCount = 0;
        deathText = GetComponent<TextMeshProUGUI>();
        deathText.SetText(deathCount.ToString());
    }

    private void Start()
    {
        ZombieSpawnManager.instance.OnHumanDeath += ZombieSpawnManager_UpdateDeathCount;
    }

    private void ZombieSpawnManager_UpdateDeathCount(object sender, System.EventArgs e)
    {
        UpdateDeathCount();
    }

    private void UpdateDeathCount()
    {
        deathCount++;
        deathText.SetText(deathCount.ToString());
        if(deathCount >= LevelData.numberOfKillsNeededToWin)
        {
            LevelData.CompleteLevel();
        }
    }
}
