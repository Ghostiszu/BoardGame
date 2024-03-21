using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSystem : StateMachine
{   
    public Transform unit01Station;
    public Transform unit02Station;
    public GameObject unit01Prefab;
    public GameObject unit02Prefab;

    
    public Unit unit01;
    public Unit unit02;

    public GameObject unit01GameObject;
    public GameObject unit02GameObject;

    public Unit attacker;
    public Unit defender;

    public int turnCount;
    
    public string attackType;
    public string defendType;

    [SerializeField] GameManager gameManager;

    [SerializeField] GameObject battleArea;
    [SerializeField] GameObject boardArea;
    //[SerializeField] DataManager dataManager;

    private void OnEnable() {
        turnCount = 1;
        unit01Prefab = Node.playerOnNode;
        SetState(new BeginBattle(this));
    }

    public void LeftButton()
    {
        State.LeftButton();
    }

    public void RightButton()
    {
        State.RightButton();
    }

    public void UpButton()
    {
        State.UpButton();
    }

    public void DownButton()
    {
        State.DownButton();
    }

    public void ConfirmButton()
    {
        State.ConfirmButton();
    }

    public void EndBattle()
    {
        //dataManager.Save_Data();
        if(unit01.currentHp > 0 || unit02.currentHp > 0)
        {
            Node.playerOnNode.GetComponent<PlayerMovement>().isFighting = true;
        }
        
        battleArea.SetActive(false);
        boardArea.SetActive(true);
        Destroy(unit01GameObject);
        Destroy(unit02GameObject);
        gameManager.currentPlayerTurn.DeActiveTurn();
        gameManager.SetNextTurn();


    }




}
