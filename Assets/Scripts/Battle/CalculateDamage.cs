using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDamage : State
{
    int damage;

    public CalculateDamage(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    public override IEnumerator Start()
    {
        CalculateCombat();
        yield return new WaitForSeconds(2f);

    }

    void CalculateCombat()
    {
        //Random minMax Multipler
        float[] rand = {0.95f,1.05f};
        int randIndex = UnityEngine.Random.Range(0,2);
        float minMax = rand[randIndex];
        damage = 0;

        //Damage Calculate
        //ATK
        if(BattleSystem.attackType == "Attack" && BattleSystem.defendType == "Guard")
        {
            damage = (int)(((BattleSystem.attacker.unitATK * 5.6f - BattleSystem.defender.unitDEF * 2.4f) * 0.5f) * minMax);
        }
        else if(BattleSystem.attackType == "Attack" && BattleSystem.defendType == "MagicDef")
        {
            damage = (int)(((BattleSystem.attacker.unitATK * 5.6f - BattleSystem.defender.unitDEF * 2.4f) * 0.7f) * minMax);
        }
        else if(BattleSystem.attackType == "Attack" && BattleSystem.defendType == "Counter")
        {
            damage = (int)(((BattleSystem.attacker.unitATK * 5.6f - BattleSystem.defender.unitDEF * 2.4f) * 0.9f) * minMax);
        }
        //Magic
        if(BattleSystem.attackType == "Magic" && BattleSystem.defendType == "Guard")
        {
            damage = (int)(((BattleSystem.attacker.unitMG * 2.4f - BattleSystem.defender.unitDEF * 2.4f) * 0.5f) * minMax);
        }

        GiveDamage();

    }


    private void GiveDamage()
    {
        bool isDead = BattleSystem.defender.TakeDamage(damage);
        //enemyHUD.SetHP(enemyUnit.currentHp);
        Debug.Log("Turn: " + BattleSystem.turnCount +" End.");
        BattleSystem.turnCount++;

        if(isDead)
        {
            BattleSystem.SetState(new EndBattle(BattleSystem));
        }
        else
        {
            BattleSystem.SetState(new TurnSystem(BattleSystem));
        }
    }

    
}
