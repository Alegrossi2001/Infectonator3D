using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponTemplateManager : MonoBehaviour
{
    private void Awake()
    {
        Transform weaponTemplate = transform.Find("WeaponTemplate");
        weaponTemplate.gameObject.SetActive(false);

        WeaponTypeList weaponTypeList = Resources.Load<WeaponTypeList>(typeof(WeaponTypeList).Name);
        float offsetAmount = 350;
        int index = 0;
        foreach (WeaponType weapon in weaponTypeList.list)
        {
            Transform weaponTransform = Instantiate(weaponTemplate, transform);
            weaponTransform.gameObject.SetActive(true);
            weaponTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);
            //Change text
            weaponTransform.Find("WeaponName").GetComponent<TextMeshProUGUI>().SetText(weapon.namestring);
            //Get image
            weaponTransform.Find("Image").GetComponent<Image>().sprite = weapon.image;
            //add listener to equip the weapon
            weaponTransform.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                Inventory.instance.EquipWeapon(weapon);
            });
            index++;

        }
    }
}
