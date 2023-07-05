using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter 
{
    UnityEngine.AI.NavMeshAgent agent { get; }
    Animator anim { get; }
}
