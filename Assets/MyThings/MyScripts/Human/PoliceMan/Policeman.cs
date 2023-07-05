using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Policeman : Human, IZombifiable
{
    public readonly float attackDistance = 10f;
    private void FixedUpdate()
    {
        HandleStateMachine();
        CheckForTarget();
    }


    new public void HandleStateMachine()
    {
        State nextState;
        if (currentState != null)
        {
            nextState = currentState.Tick(this);
            if (nextState != null)
            {
                currentState = nextState;
            }
        }
    }
}
