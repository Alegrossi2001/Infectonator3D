using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZombieState : State
{
    [SerializeField] private StrollState strollState;
    public override State Tick(Policeman character)
    {
        if (character.target != null)
        {
            //Check for distance between target and policeman
            if (character.DistanceFromTarget() <= character.attackDistance)
            {
                character.agent.isStopped = true;
                character.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                character.anim.SetLayerWeight(1, 1);
                RotateTowardsNearestZombie(character);
                return this;
            }
            //Too far away, get closer to the enemy
            else
            {
                character.agent.SetDestination(character.target.position);
                return this;
            }
        }
        //no target, go back to strolling
        else
        {
            character.agent.isStopped = false;
            character.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            character.anim.SetLayerWeight(1, 0);
            return strollState;
        }
    }

    private void RotateTowardsNearestZombie(Human character)
    {
        character.transform.LookAt(character.target);
    }
}
