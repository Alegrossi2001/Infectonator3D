using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSelectUI : MonoBehaviour
{
    [SerializeField] private Transform zombieButtonTemplate;
    [SerializeField] private int SlotsAvailable;

    //private void Awake()
    //{
    //    zombieButtonTemplate.gameObject.SetActive(false);

    //    ZombieTypeListSO zombieTypeList = Resources.Load<ZombieTypeListSO>(typeof(ZombieTypeListSO).Name);

    //    for (int i= 0; i <= SlotsAvailable; i++)
    //    {
    //        Transform btnTransform = Instantiate(zombieButtonTemplate, transform);
    //        btnTransform.gameObject.SetActive(true);
    //        btnTransform.GetComponentInChildren<Image>().sprite = zombieTypeList.zombies[i].sprite;
    //    }
    //}
}
