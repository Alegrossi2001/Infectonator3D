using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    //singleton
    public static LevelManager instance { get; private set; }

    //level
    [SerializeField] private GameObject levelPanel;
    private Level selectedLevel;

    private void Awake()
    {
        instance = this;
    }


    public GameObject GetLevelPanel()
    {
        return levelPanel;
    }

    public void SetLevelCard(Level level)
    {
        levelPanel.SetActive(true);
        TextMeshProUGUI title = levelPanel.transform.Find("Title").GetComponent<TextMeshProUGUI>();
        title.SetText(level.name);
        TextMeshProUGUI description = levelPanel.transform.Find("Description").GetComponent<TextMeshProUGUI>();
        description.SetText(level.name + " contains " + level.numberOfPeople + " humans. Kill " + level.numberOfKillsNeededToWin + " to win");
    }

    public void RemoveLevelCard()
    {
        levelPanel.SetActive(false);
    }

    public void SetLevel(Level level)
    {
        selectedLevel= level;
    }

    public void SetSpecificLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void LoadSelectedLevel(Level level)
    {
        SceneManager.LoadSceneAsync(level.name);
        LevelData.ModifyLevelDetails(level);
    }
}
