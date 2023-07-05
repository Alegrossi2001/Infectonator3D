using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public virtual State Tick(Human character)
    {
        return this;
    }

    public virtual State Tick(Zombie character)
    {
        return this;
    }

    public virtual State Tick(Character character)
    {
        return this;
    }

    public virtual State Tick(Policeman character)
    {
        return this;
    }
}
