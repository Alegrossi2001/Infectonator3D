using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HumanCount : MonoBehaviour
{
    private TextMeshProUGUI humansInScene;

    private void Start()
    {
        humansInScene = GetComponent<TextMeshProUGUI>();
        Human[] humansArray = Object.FindObjectsOfType<Human>();
        humansInScene.SetText(humansArray.Length.ToString());
    }
}
