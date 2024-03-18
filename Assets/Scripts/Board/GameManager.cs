using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> playersListPrefab;
    [SerializeField] List<GameObject> playersList;
    [SerializeField] Transform boardArea;

    int playerIndex = 0;
    public Player currentPlayerTurn;
    
    void Start()
    {
        for (int i = 0; i < playersListPrefab.Count; i++)
        {
            playersList.Add(Instantiate(playersListPrefab[i],boardArea));
        }
        currentPlayerTurn = playersList[0].GetComponent<Player>();
        SetTurn();
    }

    public void SetTurn()
    {
        currentPlayerTurn.ActiveTurn();
    }

    public void SetNextTurn()
    {
        playerIndex++;
        if(playerIndex > playersList.Count -1)
        {
            playerIndex = 0;
        }
        currentPlayerTurn = playersList[playerIndex].GetComponent<Player>();
        SetTurn();
    }

}
