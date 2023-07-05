using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Infector : Weapon
{

    private bool breakCoroutine;
    [SerializeField] private GameObject greenExplosionvfx;

    //this can be turned in an event.

    void Update()
    {
        if(WeaponManager.instance.infectorCharges > 0)
        {
            if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                TriggerWeapon(greenExplosionvfx);
                WeaponManager.instance.infectorCharges--;
            }
        }
        else 
        {
            if(breakCoroutine == false)
            {
                StartCoroutine(WaitBeforeDisablingCollision());
            }
        }
    }

    private IEnumerator WaitBeforeDisablingCollision()
    {
        
        yield return new WaitForSeconds(0.1f);
        col.enabled = false;
        breakCoroutine = true;
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other);
        IZombifiable canTurnToZombie = other.collider.gameObject.GetComponent<IZombifiable>();
        if(canTurnToZombie != null)
        {
            canTurnToZombie.TurnIntoAZombie(other.transform.GetComponent<Human>().canBeTurnedIntoAZombie);
        }
    }
}
