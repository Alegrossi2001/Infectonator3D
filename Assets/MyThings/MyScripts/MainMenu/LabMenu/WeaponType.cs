using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/WeaponType")]
public class WeaponType : ScriptableObject
{
    public string namestring;
    public int cost;
    public Sprite image;
    public GameObject gameObject;
}
