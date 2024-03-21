using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginBattle : State
{
    public BeginBattle(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    public void Full()
    {
        
    }
    

    public override IEnumerator Start()
    {
        
        BattleSystem.unit01GameObject = BattleSystem.Instantiate(BattleSystem.unit01Prefab, BattleSystem.unit01Station);
        DataManager.PlayerNumber playerNumber = BattleSystem.unit01GameObject.GetComponent<Player>().playerNumber;
        BattleSystem.unit01 = DataManager.Instance.playerData[playerNumber];
        
        BattleSystem.unit02GameObject = BattleSystem.Instantiate(BattleSystem.unit02Prefab, BattleSystem.unit02Station);
        BattleSystem.unit02 = DataManager.Instance.enemyData[BattleSystem.unit02Prefab.GetComponent<Enemy>().enemyName];

        yield return new WaitForSeconds(2f);

        BattleSystem.SetState(new SetUpAttackerDefender(BattleSystem));
    }
}
