using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpAttackerDefender : State
{
    private string[] cardDeck = new string[2]{"Attack", "Defend"};
    private int currentCard;

    public SetUpAttackerDefender(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    public override IEnumerator Start()
    {
        Debug.Log("Pick a Card");
        SetupUI();
        RandomBattleCard();
        yield return new WaitForSeconds(2f);
    }

    public override void LeftButton()
    {
        currentCard--;
            if(currentCard < 0)
                currentCard = 1;  
    }

    public override void RightButton()
    {
        currentCard++;
            if(currentCard > 1)
                currentCard = 0;   
    }

    public override void ConfirmButton()
    {
        AssignAttackerDefender();
    }

    public void SetupUI()
    {
        //show BattleCard UI
    }

    void RandomBattleCard()
    {
        currentCard = UnityEngine.Random.Range(0,2);
    }

    void AssignAttackerDefender()
    {
        if(cardDeck[currentCard] == "Attack")
        {
            //unit01 Attack first
            BattleSystem.attacker = BattleSystem.unit01;
            BattleSystem.defender = BattleSystem.unit02;
            Debug.Log("You are Attacker");
        }
        else if(cardDeck[currentCard] == "Defend")
        {
            //unit02 Attack first
            BattleSystem.attacker = BattleSystem.unit02;
            BattleSystem.defender = BattleSystem.unit01;
            Debug.Log("You are Defender");
        }
        

        BattleSystem.SetState(new TurnSystem(BattleSystem));
    }

    

    
}
