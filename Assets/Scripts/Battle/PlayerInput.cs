using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : StateMachine
{
    [SerializeField] BattleSystem battleSystem;

    
    private void Start() 
    {
        battleSystem = GetComponent<BattleSystem>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            battleSystem.LeftButton();
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            battleSystem.RightButton();
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            battleSystem.UpButton();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            battleSystem.DownButton();
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            battleSystem.ConfirmButton();
        }
    }
}
