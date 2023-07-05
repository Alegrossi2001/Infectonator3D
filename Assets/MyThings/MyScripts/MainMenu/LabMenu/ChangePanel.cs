using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePanel : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;

    public void SetActivePanel(GameObject thisPanel)
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        thisPanel.SetActive(true);
    }
}
