using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardStateMachine : MonoBehaviour
{
    protected BoardState BoardState;

    public void SetState(BoardState boardState)
    {
        BoardState = boardState;
        StartCoroutine(BoardState.Start());
    }
}
