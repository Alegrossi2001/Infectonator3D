using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Character, IZombifiable
{
    
    public bool canBeTurnedIntoAZombie;
    public Human humanCharacter;
    public float displacementDistance = 4f;
    public StrollState strollState;
    [Range(0, 100)]
    [SerializeField] private int chanceOfPatrol;

    private void Awake()
    {
        humanCharacter = this;
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        startingState = ChanceOfPatrolling();
        currentState = startingState;
    }

    private State ChanceOfPatrolling()
    {
        if(UnityEngine.Random.Range(0,100) < chanceOfPatrol)
        {
            return strollState;
        }
        else
        {
            return idleState;
        }
    }
    public void TurnIntoAZombie(bool canBeTurnedIntoAZombie)
    {
        if (canBeTurnedIntoAZombie)
        {
            agent.isStopped = true;
            if(humanCharacter != null)
            {
                ZombieSpawnManager.instance.KillHuman(this);

            }
        }
        else
        {
            KillHuman();
        }
    }

    private void FixedUpdate()
    {
        HandleStateMachine();
        CheckForTarget();
    }

    public void HandleStateMachine()
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

    public void CheckForTarget()
    {
        if (target != null)
        {
            if (target.GetComponent<Zombie>().isDead == true)
            {
                if (target.GetComponent<Zombie>().enabled == false)
                {
                    target = null;
                }
            }
        }
    }

    private void KillHuman()
    {
        Destroy(this.gameObject);
    }
}
