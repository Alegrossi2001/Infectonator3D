using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Zombie/ZombieType")]
public class ZombieType : ScriptableObject
{
    public string namestring;
    public string description;
    public GameObject gameObject;
    public Sprite image;
}
