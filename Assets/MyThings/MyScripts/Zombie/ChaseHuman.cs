using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseHuman : State
{
    [SerializeField] private AttackState attackState;
    [SerializeField] private SeekHumanState seekHumanState;

    public override State Tick(Zombie character)
    {
        if (character.target != null)
        {
            ChaseTarget(character);
            character.anim.SetLayerWeight(1, Mathf.Lerp(character.anim.GetLayerWeight(1), 0, Time.deltaTime * 13f));
            if (character.DistanceFromTarget() < character.attackDistance)
            {

                return attackState;
            }
        }
        
        else if(character.target == null)
        {
            return seekHumanState;
        }
        return this;
    }

    private void ChaseTarget(Zombie character)
    {
        character.anim.SetFloat("Vertical", character.zombieAnimationSpeed);
        if(character.target.position != null)
        {
            character.agent.SetDestination(character.target.position);
        }

    }
}
