using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    //states
    public State currentState;
    public State startingState;
    public IdleState idleState;

    //AI
    public bool attacksTarget;
    public float patrolSphere;
    public Animator anim;
    public UnityEngine.AI.NavMeshAgent agent;

    //Detection
    public float detectionRadius;
    public LayerMask detectionLayer;
    public Transform target;

    //combat
    public int damage;
    //stats
    public int health;
    public bool isDead;

    public float DistanceFromTarget()
    {
        if(target != null)
        {
            return Vector3.Distance(this.transform.position, this.target.position);
        }
        else
        {
            Debug.Log(Mathf.Infinity);
            return Mathf.Infinity;
        }
    }

    public void ReduceHealth(int healthAmount, bool turnToZombie = true)
    {
        health -= healthAmount;
        if(health <= 0)
        {
            isDead = true;
            agent.isStopped = true;
            GameObject character = this.gameObject;
            IZombifiable isItAHuman = character.GetComponent<IZombifiable>();
            if (isItAHuman != null)
            {
                isItAHuman.TurnIntoAZombie(character.GetComponent<Human>().canBeTurnedIntoAZombie);
            }
        }
    }
}
