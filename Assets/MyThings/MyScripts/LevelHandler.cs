using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelHandler : MonoBehaviour
{
    private int deathCount;
    private int timeBeforeExit = 5;
    [SerializeField] private TextMeshProUGUI timer;
    
    void Start()
    {
        ZombieSpawnManager.instance.OnHumanDeath += ZombieSpawnManager_UpdateDeathCount;
    }

    private void ZombieSpawnManager_UpdateDeathCount(object sender, System.EventArgs e)
    {
        deathCount++;
        if(deathCount >= (LevelData.numberOfPeople + LevelData.numberOfPolice))
        {
            ExitLevel();
        }
    }

    private void ExitLevel()
    {
        SceneManager.LoadScene("WorldMap");
        this.transform.GetChild(0).gameObject.SetActive(true);

        //add gold based on the number of kills.
        GoldManager.AddGold(deathCount * 10);

    }
}
