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
        BattleSystem.unit01 = BattleSystem.unit01GameObject.GetComponent<Unit>();
        
        BattleSystem.unit02GameObject = BattleSystem.Instantiate(BattleSystem.unit02Prefab, BattleSystem.unit02Station);
        BattleSystem.unit02 = BattleSystem.unit02GameObject.GetComponent<Unit>();

        yield return new WaitForSeconds(2f);

        BattleSystem.SetState(new SetUpAttackerDefender(BattleSystem));
    }
}
