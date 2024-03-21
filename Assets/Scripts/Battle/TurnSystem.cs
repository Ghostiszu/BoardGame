using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : State
{
    public TurnSystem(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    public override IEnumerator Start()
    {
        if(BattleSystem.turnCount == 1)
        {
            Debug.Log("Turn : " + BattleSystem.turnCount);
            BattleSystem.SetState(new Unit01CombatInput(BattleSystem));
        }
        else if(BattleSystem.turnCount == 2)
        {
            SwapTurn(); 
        }
        else if(BattleSystem.turnCount >= 3)
        {
            BattleSystem.SetState(new EndBattle(BattleSystem));
        }
        yield return new WaitForSeconds(2f);
    }

    public void SwapTurn()
    { 
        if(BattleSystem.unit01.Equals(BattleSystem.attacker) && BattleSystem.unit02.Equals(BattleSystem.defender))
        {
            BattleSystem.defender = BattleSystem.unit01;
            BattleSystem.attacker = BattleSystem.unit02;
        }
        else if(BattleSystem.unit01.Equals(BattleSystem.defender) && BattleSystem.unit02.Equals(BattleSystem.attacker))
        {
            BattleSystem.defender = BattleSystem.unit02;
            BattleSystem.attacker = BattleSystem.unit01;
        }

        Debug.Log("Swap Turn");
        BattleSystem.SetState(new Unit01CombatInput(BattleSystem));
    }
}
