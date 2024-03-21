using System;
using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    
    [SerializedDictionary("Player Number","Player Data")]
    public SerializedDictionary<PlayerNumber, Unit> playerData = new SerializedDictionary<PlayerNumber, Unit>();
    [SerializedDictionary("Enemy Name","Enemy Data")]
    public SerializedDictionary<EnemyName, Unit> enemyData = new SerializedDictionary<EnemyName, Unit>();
    [SerializedDictionary("Enemy Name","Enemy Data")]
    public SerializedDictionary<String, Unit> enemyInCombat = new SerializedDictionary<String, Unit>();
    

    private int saved_currentHp;

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
        }

        enemyInCombat.Add("Goblin_1",enemyData[EnemyName.Goblin]);
       
        //DataManager.Instance.playerData.Add(PlayerNumber.Player2, );
        //playerData.TryGetValue(PlayerNumber.Player1,out var playerData1);
        //Debug.Log(playerData1.maxHP);

    }
    
    public enum PlayerNumber
    {
        Player1, Player2, Player3, Player4
    }

    public enum EnemyName
    {
        Goblin
    }
}
