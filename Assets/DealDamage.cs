using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private Character thisCharacter;

    private void Awake()
    {
        thisCharacter = GetComponentInParent<Character>();
    }
    void OnCollisionEnter(Collision other)
    {
        Human hitHuman = other.gameObject.GetComponent<Human>();
        if (hitHuman != null)
        {
            if(hitHuman.isDead == false)
            {
                hitHuman.ReduceHealth(thisCharacter.damage);
            }
        }

        Policeman policeman = other.gameObject.GetComponent<Policeman>();
        if (policeman != null)
        {
            if (policeman.isDead == false)
            {
                policeman.ReduceHealth(thisCharacter.damage);
            }
        }
    }
}
