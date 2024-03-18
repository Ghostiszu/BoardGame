using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoardState
{
    protected BoardSystem BoardSystem;
    
    public BoardState(BoardSystem boardSystem)
    {
        BoardSystem = boardSystem;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }
}
