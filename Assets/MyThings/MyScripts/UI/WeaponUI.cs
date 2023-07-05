using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponUI : MonoBehaviour
{
    private void Start()
    {
        Image imageToChange = this.transform.Find("Button").GetComponent<Image>();
        
        if(WeaponData.currentWeapon == null)
        {
            this.gameObject.SetActive(false);
        }

        imageToChange.sprite = WeaponData.currentWeapon.image;
    }
}
