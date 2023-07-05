using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekHumanState : State
{
    private Transform targetTransform;
    [SerializeField] private ChaseHuman chaseState;
    public override State Tick(Zombie character)
    {
        SeekHuman(character);
        if(character.target != null)
        {
            return chaseState;
        }
        return this;
    }

    private void SeekHuman(Zombie zombie)
    {
        float targetMaxRadius = 30f;
        Collider[] colliders = Physics.OverlapSphere(zombie.transform.position, targetMaxRadius);
        foreach(Collider col in colliders)
        {
            Human humanInRange = col.GetComponent<Human>();
            if(humanInRange != null)
            {
                if (targetTransform == null)
                {
                    targetTransform = humanInRange.transform;
                    zombie.target = targetTransform;

                }
                else
                {
                    if (Vector3.Distance(transform.position, humanInRange.transform.position) < Vector3.Distance(transform.position, targetTransform.position))
                    {
                        targetTransform = humanInRange.transform;
                        zombie.target = targetTransform;
                    }
                }
            }
            
        }
    }
}


