using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeaponData
{
    public static WeaponType currentWeapon { get; private set; }

    public static void LoadWeapon(WeaponType weapon)
    {
        currentWeapon= weapon;
    }
}
