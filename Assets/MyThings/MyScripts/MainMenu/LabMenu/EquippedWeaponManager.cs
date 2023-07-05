using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EquippedWeaponManager : MonoBehaviour
{
    private Transform equippedWeaponTemplate;

    private void Start()
    {
        Inventory.instance.OnWeaponSelect += Inventory_DisplayEquippedWeapon;
        equippedWeaponTemplate = transform.Find("EquippedWeaponSlot");
        equippedWeaponTemplate.gameObject.SetActive(false);
    }

    private void Inventory_DisplayEquippedWeapon(object sender, Inventory.OnWeaponSelectEventArgs e)
    {
        equippedWeaponTemplate.gameObject.SetActive(true);
        equippedWeaponTemplate.Find("WeaponName").GetComponent<TextMeshProUGUI>().SetText(e.weapon.namestring);
        equippedWeaponTemplate.Find("Image").GetComponent<Image>().sprite = e.weapon.image;
        WeaponData.LoadWeapon(e.weapon);

    }
}
