using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekZombieState : State
{
    private Transform targetTransform;
    public override State Tick(Human character)
    {
        SeekZombie(character);
        if(character.target != null)
        {
            //Change to fleestate
            return this;
        }
        return this;
    }

    public void SeekZombie(Human human)
    {
        float targetMaxRadius = 7f;
        Collider[] colliders = Physics.OverlapSphere(human.transform.position, targetMaxRadius);
        foreach(Collider col in colliders)
        {
            Zombie zombieInRange = col.GetComponent<Zombie>();
            if(zombieInRange != null)
            {
                if(zombieInRange.enabled == true)
                {
                    if (targetTransform == null)
                    {
                        targetTransform = zombieInRange.transform;
                        human.target = targetTransform;

                    }
                    else
                    {
                        if (Vector3.Distance(transform.position, zombieInRange.transform.position) < Vector3.Distance(transform.position, targetTransform.position))
                        {
                            targetTransform = zombieInRange.transform;
                            human.target = targetTransform;
                        }
                    }
                }

            }
            
        }
    }
}


