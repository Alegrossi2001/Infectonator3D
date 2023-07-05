using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayState : State
{
    private float displacementDistance = 15f;
    private StrollState strollState;

    private void Awake()
    {
        strollState = GetComponent<StrollState>();
    }
    public override State Tick(Human character)
    {
        if(displacementDistance > character.DistanceFromTarget())
        {
            Vector3 dirToZombie = character.transform.position - character.target.position;
            Vector3 newPos = character.transform.position + dirToZombie;
            FleeToPos(newPos, character);
            return this;
        }
        else if(displacementDistance < character.DistanceFromTarget() || character.target == null)
        {
            character.anim.SetFloat("Vertical", 0.5f, 0.2f, Time.deltaTime);
            return strollState;
        }

        return this;    
    }

    private void FleeToPos(Vector3 pos, Character character)
    {
        character.agent.speed = 3f;
        character.agent.SetDestination(pos);
        character.agent.isStopped = false;
        character.anim.SetFloat("Vertical", 1, 0.2f, Time.deltaTime);
    }
}
