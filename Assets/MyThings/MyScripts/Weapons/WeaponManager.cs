using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int infectorCharges = 1;

    [SerializeField] private GameObject infector;
    public static WeaponManager instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public void ToggleInfector()
    {
        if(infectorCharges> 0)
        {
            infector.SetActive(true);
        }
    }

    public void ToggleWeapon()
    {
        Instantiate(WeaponData.currentWeapon.gameObject, Vector3.zero, Quaternion.identity);
    }
}
