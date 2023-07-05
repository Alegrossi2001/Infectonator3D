using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected Collider col;

    public void Awake()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    public void TriggerWeapon(GameObject explosive)
    {
        col.enabled = true;
        this.transform.position = MouseWorld.GetPosition();
        Instantiate(explosive, this.transform.position, Quaternion.identity);
    }
}
