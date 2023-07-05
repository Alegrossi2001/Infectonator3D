using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrollState : SeekZombieState
{
    private Transform centrePoint;
    private int waitTime;
    private float timer;
    private RunAwayState runAwayState;
    private AttackZombieState attackState;
    private void Awake()
    {
        centrePoint = this.transform;
        waitTime = UnityEngine.Random.Range(2, 5);
        runAwayState = GetComponent<RunAwayState>();
        attackState = GetComponent<AttackZombieState>();
    }
    public override State Tick(Human character)
    {
        
        timer += Time.deltaTime;
        SeekZombie(character);
        if (character.target != null && character.DistanceFromTarget() < character.displacementDistance)
        {
            return runAwayState;
        }
        HumanPatrol(character);
        return this;
    }

    public override State Tick(Policeman character)
    {
        timer += Time.deltaTime;
        SeekZombie(character);
        if (character.target != null && character.DistanceFromTarget() < character.displacementDistance)
        {
            //fight the zombie
            return attackState;
        }
        HumanPatrol(character);
        return this;
    }

    private void HumanPatrol(Human human)
    {
        if (human.agent.remainingDistance <= human.agent.stoppingDistance) //done with path
        {
            human.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            Vector3 point;
            if (RandomPoint(centrePoint.position, human.patrolSphere, out point)) //pass in our centre point and radius of area
            {
                if (timer >= waitTime) //head to new destination
                {
                    human.agent.SetDestination(point);
                    human.anim.SetFloat("Vertical", 0.5f);
                    timer = 0;
                }
            }
        }

        
    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range; //random point in a sphere 
        UnityEngine.AI.NavMeshHit hit;
        if (UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas)) 
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
