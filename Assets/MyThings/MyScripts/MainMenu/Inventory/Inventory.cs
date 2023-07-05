using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public static Inventory instance { get; private set; }
    private InventoryZombieManager equippedZombies;
    public readonly int zombieInventoryMaxCapacity = 3;
    private WeaponType chosenWeapon;
    //here we call an event that the player has selected a zombie
    public event EventHandler<OnZombieSelectEventArgs> OnZombieSelect;
    //here we call an event that the player has selected a weapon
    public event EventHandler<OnWeaponSelectEventArgs> OnWeaponSelect;

    private void Awake()
    {
        instance = this;
        equippedZombies = GetComponent<InventoryZombieManager>();
    }

    public class OnZombieSelectEventArgs : EventArgs
    {
        public List<ZombieType> equippedZombieList;
    }

    public class OnWeaponSelectEventArgs : EventArgs
    {
        public WeaponType weapon;
    }



    public void AddZombieToEquipment(ZombieType zombie)
    {
        //checks for duplicates and removes the oldest zombie selected
        if (!equippedZombies.equippedZombie.Contains(zombie))
        {
            if (equippedZombies.equippedZombie.Count >= zombieInventoryMaxCapacity)
            {
                equippedZombies.equippedZombie.RemoveAt(0); // Remove oldest zombie (first item in the list)
            }
            equippedZombies.equippedZombie.Add(zombie);
            //call event
            OnZombieSelect?.Invoke(this,
            new OnZombieSelectEventArgs { equippedZombieList = equippedZombies.equippedZombie }
        );
        }

        
        
    }

    public void EquipWeapon(WeaponType weapon)
    {
        //check if player has selected a different weapon before firing the event. This is for performance.
        if(weapon != chosenWeapon)
        {
            chosenWeapon = weapon;
            OnWeaponSelect?.Invoke(this,
            new OnWeaponSelectEventArgs { weapon = weapon }
        );
        }
    }



}
