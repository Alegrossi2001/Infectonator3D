using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bomb : Weapon
{
    //testing
    private bool isExplosionTriggered;
    [SerializeField] private GameObject explosion;

    void Update()
    {
        if(isExplosionTriggered == false)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                this.gameObject.SetActive(true);
                TriggerWeapon(explosion);
                isExplosionTriggered= true;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Human human = other.gameObject.GetComponent<Human>();
        if (human != null)
        {
            human.ReduceHealth(50);
        }
    }
}
