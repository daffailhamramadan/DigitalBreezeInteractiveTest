using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NinjaState
{
    protected NinjaController ninja;

    public NinjaState(NinjaController ninja)
    {
        this.ninja = ninja;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
