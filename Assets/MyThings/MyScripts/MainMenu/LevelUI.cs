using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour
{

    [SerializeField] private Level thisLevel;
    private LevelManager levelManager;

    private void Awake()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    public void LevelPanelInstantiate()
    {
        levelManager.SetLevelCard(thisLevel);
        levelManager.SetLevel(thisLevel);
    }

    public void LoadLevel()
    {
        levelManager.LoadSelectedLevel(thisLevel);
    }
}
