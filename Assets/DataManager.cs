using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private int saved_currentHp;

    [SerializeField] BattleSystem battleSystem;
    
    public void Save_Data()
    {
        saved_currentHp = battleSystem.unit01.currentHp;
        TrasnferData();
    }

    void TrasnferData()
    {
        playerData player = Node.playerOnNode.GetComponent<playerData>();
        player.currentHp = saved_currentHp;
    }
}
