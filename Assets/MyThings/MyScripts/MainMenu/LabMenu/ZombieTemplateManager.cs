using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ZombieTemplateManager : MonoBehaviour
{
    private void Awake()
    {
        Transform zombieTemplate = transform.Find("ZombieTemplate");
        zombieTemplate.gameObject.SetActive(false);

        ZombieTypeList zombieTypes = Resources.Load<ZombieTypeList>(typeof(ZombieTypeList).Name);
        float offsetAmount = 350;
        int index = 0;
        foreach(ZombieType zombie in zombieTypes.list)
        {
            Transform zombieTransform = Instantiate(zombieTemplate, transform);
            zombieTransform.gameObject.SetActive(true);
            zombieTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);
            //Change text
            zombieTransform.Find("ZombieName").GetComponent<TextMeshProUGUI>().SetText(zombie.namestring);
            //Get image
            zombieTransform.Find("Image").GetComponent<Image>().sprite = zombie.image;
            //add listener to equip the zombie
            zombieTransform.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                Inventory.instance.AddZombieToEquipment(zombie);
            });
            index++;

        }
    }
}
