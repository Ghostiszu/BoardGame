using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit01CombatInput : State
{
    

    public Unit01CombatInput(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    public override IEnumerator Start()
    {

        yield return new WaitForSeconds(2f);

    }

    public override void LeftButton()
    {
        if(BattleSystem.unit01.Equals(BattleSystem.attacker))
        {
            BattleSystem.attackType = "Strike";
            
        }
        else if(BattleSystem.unit01.Equals(BattleSystem.defender))
        {
            BattleSystem.defendType = "Counter";
        }
        BattleSystem.SetState(new Unit02CombatInput(BattleSystem));
    }

    public override void RightButton()
    {
        if(BattleSystem.unit01.Equals(BattleSystem.attacker))
        {
            BattleSystem.attackType = "Attack";
        }
        else if(BattleSystem.unit01.Equals(BattleSystem.defender))
        {
            BattleSystem.defendType = "Guard";
        }
        BattleSystem.SetState(new Unit02CombatInput(BattleSystem));
    }

    public override void UpButton()
    {
        if(BattleSystem.unit01.Equals(BattleSystem.attacker))
        {
            BattleSystem.attackType = "Magic";
        }
        else if(BattleSystem.unit01.Equals(BattleSystem.defender))
        {
            BattleSystem.defendType = "MagicDef";
        }
        BattleSystem.SetState(new Unit02CombatInput(BattleSystem));
    }
    

    public void SetupUI()
    {
        //show battle input for Attacker and Defender
    }

}
