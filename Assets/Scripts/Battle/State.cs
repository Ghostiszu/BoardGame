using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected BattleSystem BattleSystem;

    public State(BattleSystem battleSystem)
    {
        BattleSystem = battleSystem;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual void LeftButton()
    {

    }

    public virtual void RightButton()
    {
        
    }

    public virtual void UpButton()
    {

    }

    public virtual void DownButton()
    {
        
    }

    public virtual void ConfirmButton()
    {
        
    }

}
