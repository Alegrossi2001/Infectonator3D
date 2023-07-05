using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Character
{
    private float survivalTime;
    private float maxSurvivalTime;
    [SerializeField] private SeekHumanState seekHumanState;
    public readonly float attackDistance = 1f;
    private Collider col;
    public float zombieAnimationSpeed;

    private void Awake()
    {
        maxSurvivalTime = ZombieData.zombieData.survivalTime;
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        startingState = seekHumanState;
        currentState = startingState;
        survivalTime = 0f;
        col = GetComponent<Collider>();
        agent.speed = ZombieData.zombieData.speed;
        ChangeZombieAnimationSpeed();

    }


    private void FixedUpdate()
    {
        HandleStateMachine();
        UpdateSurvivalTime();
        
    }

    private void UpdateSurvivalTime()
    {
        if(survivalTime <= maxSurvivalTime)
        {
            survivalTime += Time.deltaTime;
        }
        else
        {
            ZombieDeath();
        }
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

    private void ZombieDeath()
    {
        anim.SetLayerWeight(1, 0);
        agent.isStopped = true;
        anim.Play("Standing React Death Backward");
        isDead = true;
        col.enabled = false;
        this.enabled = false;
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            ZombieDeath();
        }
    }

    private void ChangeZombieAnimationSpeed()
    {
        float divisibility = ZombieData.zombieData.speed / 0.5f;
        float multiplier = 0.1f * divisibility;
        zombieAnimationSpeed = 0.5f + multiplier;
        if(zombieAnimationSpeed > 1)
        {
            zombieAnimationSpeed = 1;
        }

    }
}
