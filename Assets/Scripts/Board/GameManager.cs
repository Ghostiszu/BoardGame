using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> playersListPrefab;
    [SerializeField] List<GameObject> playersList;
    [SerializeField] Transform boardArea;
    [SerializeField] GameObject battleGroup;
    [SerializeField] GameObject boardGroup;

    int playerIndex = 0;
    public PlayerMovement currentPlayerTurn;
    
    void Start()
    {
        SpawnPlayers();
        SetTurn();
    }

    void SpawnPlayers()
    {
        for (int i = 0; i < playersListPrefab.Count; i++)
        {
            playersList.Add(Instantiate(playersListPrefab[i],boardArea));
        }
        currentPlayerTurn = playersList[0].GetComponent<PlayerMovement>();
    }

    public void SetTurn()
    {
        currentPlayerTurn.ActiveTurn();
    }

    public void SetNextTurn()
    {
        Debug.Log("Set Next Turn");
        playerIndex++;
        if(playerIndex > playersList.Count -1)
        {
            playerIndex = 0;
        }
        currentPlayerTurn = playersList[playerIndex].GetComponent<PlayerMovement>();
        SetTurn();
    }

    public void StartBattle()
    {
        boardGroup.SetActive(false);
        battleGroup.SetActive(true);
        Debug.Log("Start Battle Event");
    }

}
