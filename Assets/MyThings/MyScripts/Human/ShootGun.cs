using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gunPosition;

    public void ShootTheGun()
    {
        Instantiate(bullet, gunPosition.position, transform.rotation);
    }
}
