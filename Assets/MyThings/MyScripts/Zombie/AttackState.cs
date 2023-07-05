using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private ChaseHuman chaseState;
    public override State Tick(Zombie character)
    {
        if(character.target != null)
        {
            if (character.DistanceFromTarget() <= character.attackDistance)
            {
                character.anim.SetLayerWeight(1, 1);
                return this;
            }
            else
            {
                return chaseState;
            }
        }
        else
        {
            character.anim.SetLayerWeight(1, 0);
            return chaseState;
        }
    }
}
