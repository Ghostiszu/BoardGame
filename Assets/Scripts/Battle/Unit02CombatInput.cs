using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit02CombatInput : State
{
    public Unit02CombatInput(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    public override IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        EnemySelectCombatType();
    }

    void EnemySelectCombatType()
    {
        int randomCombatType = UnityEngine.Random.Range(0,2);

        if(BattleSystem.unit02 == BattleSystem.attacker)
        {
            switch(randomCombatType)
            {
                case 0:
                    BattleSystem.attackType = "Attack";
                    break;
                case 1:
                    BattleSystem.attackType = "Magic";
                    break;
                case 2:
                    BattleSystem.attackType = "Strike";
                    break;
            }
        }
        else if(BattleSystem.unit02 == BattleSystem.defender)
        {
            switch(randomCombatType)
            {
                case 0:
                    BattleSystem.defendType = "Guard";
                    break;
                case 1:
                    BattleSystem.defendType = "MagicDef";
                    break;
                case 2:
                    BattleSystem.defendType = "Counter";
                    break;
            }
        }
        
        
        BattleSystem.SetState(new CalculateDamage(BattleSystem));
    }
}
