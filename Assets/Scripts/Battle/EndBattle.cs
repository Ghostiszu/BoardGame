using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBattle : State
{
    public EndBattle(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    public override IEnumerator Start()
    {
        Debug.Log("Battle End.");

        BattleSystem.EndBattle();
        yield return new WaitForSeconds(2f);
    }
}
