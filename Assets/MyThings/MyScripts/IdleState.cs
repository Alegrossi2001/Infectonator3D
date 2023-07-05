using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private RunAwayState runAwayState;
    
    public override State Tick(Zombie character)
    {
        GoIdle(character);
        return this;
    }

    public override State Tick(Human character)
    {
        GoIdle(character);
        runAwayState = GetComponent<RunAwayState>();
        return this;
    }

    private void GoIdle(Character character)
    {
        character.agent.isStopped = true;
        character.anim.SetFloat("Vertical", 0, 0.2f, Time.deltaTime);
    }
}
